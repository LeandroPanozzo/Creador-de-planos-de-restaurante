using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalRestaurante
{
    //permite arrastrar y redimensionar un botón dentro de un panel grande (largePanel) que a su vez está contenido en un
    //TableLayoutPanel.
    internal class MoverBotones
    {
        //isDragging: Indica si el botón está siendo arrastrado.
        //isResizing: Indica si el botón está siendo redimensionado.
        private bool isDragging = false;
        private bool isResizing = false;
        //startPoint: Almacena la posición inicial del cursor cuando se empieza a arrastrar o redimensionar.
        private Point startPoint = new Point(0, 0);
        //resizeMargin: Define el margen dentro del cual el botón puede ser redimensionado
        private const int resizeMargin = 10;
        //button: El botón que se desea mover o redimensionar.
        private Button button;
        //largePanel: El panel grande donde está contenido el botón.
        private Panel largePanel;
        //tableLayoutPanel: El TableLayoutPanel que contiene el largePanel
        private TableLayoutPanel tableLayoutPanel;

        /*
         El constructor recibe el botón, el panel grande y el TableLayoutPanel. Se asignan estos componentes a los atributos de la 
        clase y se suscriben los manejadores de eventos MouseDown, MouseMove y MouseUp del botón.
         */
        public MoverBotones(Button button, Panel largePanel, TableLayoutPanel tableLayoutPanel)
        {
            this.button = button;
            this.largePanel = largePanel;
            this.tableLayoutPanel = tableLayoutPanel;
            this.button.MouseDown += new MouseEventHandler(button_MouseDown);
            this.button.MouseMove += new MouseEventHandler(button_MouseMove);
            this.button.MouseUp += new MouseEventHandler(button_MouseUp);
        }


        //Verifica si el cursor está en la zona de redimensionamiento del botón (parte media inferior).
        private bool IsInResizeZone(Point mouseLocation)
        {
            // Verifica si el mouse está en la parte media inferior del botón
            int middleX = button.Width / 2;
            //Verificación si el cursor está en la zona de redimensionamiento:
            //1-Verifica si la coordenada Y del cursor está dentro de los últimos resizeMargin píxeles desde el borde inferior
            //del botón. Esto asegura que el cursor está en la parte inferior del botón.
            return mouseLocation.Y >= button.Height - resizeMargin &&
                   //2Verifica si la coordenada X del cursor está a la izquierda del punto medio del botón dentro del margen
                   //de redimensionamiento
                   mouseLocation.X >= middleX - resizeMargin &&
                   //Verifica si la coordenada X del cursor está a la derecha del punto medio del botón dentro del margen
                   //de redimensionamiento
                   mouseLocation.X <= middleX + resizeMargin;
        }


        /*
         Este evento se activa cuando se presiona el botón del ratón sobre el botón. Verifica si el clic está en la zona de
        redimensionamiento (IsInResizeZone). Si es así, establece isResizing en true. Si no, establece isDragging en true.
        Guarda la posición inicial del cursor.

        MouseButtons es una enumeración en el espacio de nombres System.Windows.Forms que especifica los botones del ratón. Los
        valores posibles de esta enumeración incluyen Left, Right, Middle, entre otros.
        MouseButtons.Left se refiere al botón izquierdo del ratón.
        MouseButtons.Right se refiere al botón derecho del ratón.
        MouseButtons.Middle se refiere al botón central del ratón (si existe)
         */
        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            //Esta línea verifica si el botón que se ha presionado es el botón izquierdo del ratón
            /*
             e es una instancia de MouseEventArgs, una clase que proporciona datos para eventos de ratón como MouseDown, MouseUp, y
            MouseMove. Esta clase está en el espacio de nombres System.Windows.Forms
            MouseEventArgs tiene varias propiedades que dan información sobre el evento del ratón. Algunas de estas propiedades son:
            Button: Indica qué botón del ratón fue presionado.
            Clicks: Indica el número de veces que se hizo clic.
            X: Obtiene la coordenada x del ratón durante el evento del ratón.
            Y: Obtiene la coordenada y del ratón durante el evento del ratón.
            Location: Obtiene las coordenadas x e y del ratón durante el evento del ratón como una Point.
             */
            if (e.Button == MouseButtons.Left)
            {
                if (IsInResizeZone(e.Location))
                {
                    isResizing = true;
                }
                else
                {
                    isDragging = true;
                }
                startPoint = new Point(e.X, e.Y); //Guarda la posición inicial del cursor.
            }
        }

        //Este evento se activa cuando se mueve el ratón sobre el botón. Dependiendo de si isDragging o isResizing es true,
        //mueve o redimensiona el botón respectivamente. También ajusta el tamaño del panel si es necesario y asegura que el
        //botón permanezca visible
        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            // Si el botón está siendo arrastrado
            if (isDragging)
            {
                // Obtiene la posición actual del ratón relativa al panel grande
                Point mousePosition = largePanel.PointToClient(Control.MousePosition);

                // Calcula la nueva posición del botón
                //Resta la posición inicial del ratón (cuando se hizo clic) para obtener la nueva posición del botón.
                int newX = mousePosition.X - startPoint.X;
                int newY = mousePosition.Y - startPoint.Y;

                // Asegurarse de que el botón no se salga del panel
                //es la posición máxima permitida en el eje X, que asegura que el botón no se extienda más allá del borde derecho del panel.
                //newX es mayor que este valor máximo, se ajusta a este valor máximo
                //largePanel.ClientSize.Width - button.Width
                //Math.Max(0...) asegura que newX no sea menor que 0, evitando que el botón se mueva fuera del borde izquierdo del panel
                newX = Math.Max(0, Math.Min(newX, largePanel.ClientSize.Width - button.Width));
                newY = Math.Max(0, Math.Min(newY, largePanel.ClientSize.Height - button.Height));

                // Mueve el botón a la nueva posición calculada
                button.Location = new Point(newX, newY);

                // Ajusta el tamaño del panel si el botón se mueve más allá de los límites del panel
                if (newX + button.Width > largePanel.Width)
                {
                    largePanel.Width = newX + button.Width + 20;
                }
                if (newY + button.Height > largePanel.Height)
                {
                    largePanel.Height = newY + button.Height + 20;
                }

                // Asegura que el botón esté visible en el tableLayoutPanel
                EnsureButtonVisible();
            }
            // Si el botón está siendo redimensionado
            else if (isResizing)
            {
                // Calcula el nuevo tamaño del botón
                int newWidth = Math.Max(20, e.X);
                int newHeight = Math.Max(20, e.Y);

                // Limita el tamaño máximo del botón al tamaño del panel
                newWidth = Math.Min(newWidth, largePanel.Width - button.Left);
                newHeight = Math.Min(newHeight, largePanel.Height - button.Top);

                // Actualización del tamaño del botón
                button.Size = new Size(newWidth, newHeight);

                // Ajusta el tamaño del panel si el botón se redimensiona más allá de los límites del panel
                if (button.Right + 20 > largePanel.Width)
                {
                    largePanel.Width = button.Right + 20;
                }
                if (button.Bottom + 20 > largePanel.Height)
                {
                    largePanel.Height = button.Bottom + 20;
                }

                // Asegura que el botón esté visible en el tableLayoutPanel
                EnsureButtonVisible();

                // Redibuja el botón para ajustarse a su nuevo tamaño
                button.Invalidate();
            }
            // Si no se está arrastrando ni redimensionando, cambia el cursor si está en la zona de redimensionamiento
            else
            {
                //Si no se está arrastrando ni redimensionando, el método verifica si el cursor está en la zona de
                //redimensionamiento para cambiar el cursor apropiadamente
                if (IsInResizeZone(e.Location))
                {
                    //Representa un cursor de redimensionamiento vertical, que generalmente se muestra como una flecha doble que
                    //apunta hacia arriba y hacia abajo. Este cursor se utiliza para indicar que un elemento (en este caso, un
                    //botón) puede ser redimensionado en la dirección vertical.
                    button.Cursor = Cursors.SizeNS;
                }
                else
                {
                    button.Cursor = Cursors.Default;
                }
            }
        }


        //Este evento se activa cuando se suelta el botón del ratón. Establece isDragging e isResizing en false
        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                isResizing = false;
            }
        }

        //Asegura que el botón se mantenga visible dentro del tableLayoutPanel, ajustando los valores de desplazamiento.
        //Esto es crucial cuando el botón se mueve o se redimensiona y parte de él podría quedar fuera de la vista del
        //tableLayoutPanel
        private void EnsureButtonVisible()
        {
            //button.Parent.PointToScreen(button.Location): Convierte la posición del botón desde coordenadas locales de su
            //contenedor a coordenadas de pantalla absolutas
            //tableLayoutPanel.PointToClient(...): Convierte esas coordenadas de pantalla absolutas de vuelta a coordenadas locales
            //dentro del tableLayoutPanel
            Point buttonLocation = tableLayoutPanel.PointToClient(button.Parent.PointToScreen(button.Location));

            // Desplazamiento horizontal
            //Verifica si la posición X del botón es menor que el valor actual del desplazamiento horizontal
            //(HorizontalScroll.Value). Si es así, ajusta el valor del desplazamiento horizontal para asegurar que el botón sea
            //visible al menos desde esa posición.
            if (buttonLocation.X < tableLayoutPanel.HorizontalScroll.Value)
            {
                tableLayoutPanel.HorizontalScroll.Value = Math.Max(buttonLocation.X, tableLayoutPanel.HorizontalScroll.Minimum);
            }
            //Condición 2: Verifica si el borde derecho del botón (calculado sumando su posición X y su ancho) está más allá del
            //área visible del tableLayoutPanel (tableLayoutPanel.ClientSize.Width). Si es así, calcula un nuevo valor de
            //desplazamiento horizontal para que el botón sea completamente visible.
            else if (buttonLocation.X + button.Width > tableLayoutPanel.HorizontalScroll.Value + tableLayoutPanel.ClientSize.Width)
            {
                int newValue = Math.Min(
                    buttonLocation.X + button.Width - tableLayoutPanel.ClientSize.Width,
                    tableLayoutPanel.HorizontalScroll.Maximum);
                tableLayoutPanel.HorizontalScroll.Value = Math.Max(newValue, tableLayoutPanel.HorizontalScroll.Minimum);
            }

            // Desplazamiento vertical
            if (buttonLocation.Y < tableLayoutPanel.VerticalScroll.Value)
            {
                tableLayoutPanel.VerticalScroll.Value = Math.Max(buttonLocation.Y, tableLayoutPanel.VerticalScroll.Minimum);
            }
            else if (buttonLocation.Y + button.Height > tableLayoutPanel.VerticalScroll.Value + tableLayoutPanel.ClientSize.Height)
            {
                int newValue = Math.Min(
                    buttonLocation.Y + button.Height - tableLayoutPanel.ClientSize.Height,
                    tableLayoutPanel.VerticalScroll.Maximum);
                tableLayoutPanel.VerticalScroll.Value = Math.Max(newValue, tableLayoutPanel.VerticalScroll.Minimum);
            }
        }
    }
}


