
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

/*
 El ícono que tiene la clase RoundButton.cs en la imagen que has proporcionado indica que esta clase ha sido agregada como un archivo de
vínculo simbólico o enlace de archivo (file link). En Visual Studio, esto significa que el archivo no se encuentra físicamente en la carpeta 
del proyecto, sino que se ha vinculado desde otra ubicación. Este vínculo permite que múltiples proyectos compartan el mismo archivo sin 
necesidad de duplicarlo en cada proyecto. Y se puso ese icono porque hereda de Button
 */
public class RoundButton : Button // extiende la funcionalidad de un botón
{
    //Este método es un método protegido que sobrescribe el comportamiento predeterminado de pintura del control Button cuando
    //se dibuja en la pantalla
    protected override void OnPaint(PaintEventArgs pevent)
    {
        //GraphicsPath graphicsPath = new GraphicsPath();: Se crea un objeto GraphicsPath, que es una serie de segmentos y curvas
        //conectados. En este caso, se utilizará para definir la forma del botón como un círculo.
        /*
         utilizada para definir una serie de formas geométricas y caminos gráficos compuestos por líneas, curvas y formas complejas.
        Esencialmente, es un contenedor para secuencias de segmentos gráficos que pueden ser utilizados para dibujar, rellenar y 
        recortar gráficos
         */
        GraphicsPath graphicsPath = new GraphicsPath();
        //graphicsPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);: Se agrega un elipse al GraphicsPath que representa
        //la forma del botón. Las coordenadas (0, 0) especifican la esquina superior izquierda del rectángulo que circunscribe el
        //elipse, y ClientSize.Width y ClientSize.Height son el ancho y alto del rectángulo delimitador, respectivamente.
        // La elipse se define por un rectángulo delimitador que se especifica mediante sus coordenadas de la esquina superior
        // izquierda (x, y) y sus dimensiones (ancho y alto)
        /*
         ClientSize es una propiedad del control Button (heredado de Control) que obtiene el tamaño del área de cliente del control.
        El área de cliente es el área dentro de un control en la que se pueden dibujar los gráficos, excluyendo los bordes y la
        barra de título si los hubiera
        ClientSize.Width y ClientSize.Height proporcionan el tamaño del botón sin incluir los bordes, permitiendo así definir el
        tamaño exacto de la elipse que llenará todo el botón.
        0, 0: Especifica que la esquina superior izquierda del rectángulo delimitador de la elipse está en las coordenadas (0, 0)
        del control, lo cual significa que la elipse comenzará desde la esquina superior izquierda del control. (es decir toma el diametro
         */
        graphicsPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
        //this.Region = new Region(graphicsPath);: Se crea una región a partir del GraphicsPath definido anteriormente y se asigna
        //a la propiedad Region del botón. Esto define el área sensible del botón y determina la región donde se puede hacer clic
        //para interactuar con él que sera todo el circulo.
        this.Region = new Region(graphicsPath);

        //Llama al método OnPaint de la clase base (Button), asegurando que se pinte el fondo y el contenido del botón según su
        //estado (normal, presionado, desactivado, etc.)
        base.OnPaint(pevent);
        //Crea un objeto Pen para dibujar líneas con un grosor de 2 píxeles y color negro.
        using (Pen pen = new Pen(Color.Black, 2))
        {
            //Configura el modo de suavizado para mejorar la calidad del borde del círculo
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //Dibuja un elipse con el Pen especificado en las coordenadas (0, 0) con el tamaño ajustado a ClientSize.Width - 1 y
            //ClientSize.Height - 1. Restar 1 al ancho y alto asegura que el borde no se superponga con el fondo del botón
            pevent.Graphics.DrawEllipse(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }
    }
}