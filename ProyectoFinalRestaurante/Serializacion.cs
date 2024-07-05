using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalRestaurante
{
    public static class DataSerializer
    {
        //Un diccionario donde las llaves son objetos Button y los valores son objetos Mesa, que almacenan información asociada a
        //cada botón (mesa del restaurante)
        //controls: Una colección de controles (Control.ControlCollection) que contiene todos los botones que se deben serializar.
        //filePath: Ruta donde se guardará el archivo JSON que contiene la información serializada.
        public static void SaveData(Dictionary<Button, Mesa> informacionMesas, Control.ControlCollection controls, string filePath)
        {
            //Se inicializa una lista botonesInfo para almacenar la información de cada botón en forma de diccionarios.
            var botonesInfo = new List<Dictionary<string, object>>();

            //Por cada botón (Button) en la colección controls:
            foreach (Button button in controls)
            {
                //Se crea un diccionario buttonInfo que almacena para almacenar información relevante sobre cada botón:
                var buttonInfo = new Dictionary<string, object>
        {
            { "Text", button.Text }, //Texto del botón
            { "Location", new { X = button.Location.X, Y = button.Location.Y } }, //Posición (coordenadas X e Y) del botón
            { "Tag", button.Tag.ToString()}, //Etiqueta del botón convertida a cadena
            { "Ancho", button.Size.Width }, // Ancho del botón
            { "Alto", button.Size.Height},  // Alto del botón
            { "Tipo", button.GetType().ToString() } // Tipo del botón (se almacena como una cadena usando GetType().ToString())
        };
                //Si el botón está asociado a una mesa en el diccionario informacionMesas, se serializa la información de la mesa
                //(MesaInfo) y se agrega al diccionario buttonInfo
                if (informacionMesas.ContainsKey(button))
                {
                    /*
                     Si el botón actual está asociado a una mesa en el diccionario informacionMesas, se serializa la información de
                    la mesa y se agrega al diccionario buttonInfo bajo la clave MesaInfo
                    Primera llamada a buttonInfo.Add: Agrega información específica de la mesa asociada al botón (si existe una asociación).
                     JsonConvert.SerializeObject(informacionMesas[button]) uso: Serializar la información de la mesa asociada a un
                    botón específico si el botón tiene una mesa asociada en el diccionario informacionMesas, se serializa esta 
                    información (que puede ser un objeto complejo) en una cadena JSON. Esta cadena JSON se agrega al diccionario 
                    buttonInfo bajo la clave "MesaInfo".
                     */
                    buttonInfo.Add("MesaInfo", JsonConvert.SerializeObject(informacionMesas[button]));
                }
                //Se añade el número total de mesas, Mesa.TotalMesas, al diccionario buttonInfo.
                /*
                 Propósito: Independientemente de si el botón tiene una mesa asociada o no, se agrega el número total de mesas al 
                diccionario buttonInfo con la clave "Total Mesas".
                 Resultado: La clave "Total Mesas" y su valor (el número total de mesas) se agregan al diccionario buttonInfo
                Segunda llamada a buttonInfo.Add: Agrega una información general sobre el número total de mesas.
                 */
                buttonInfo.Add("Total Mesas", Mesa.TotalMesas);
                //El diccionario buttonInfo se agrega a la lista botonesInfo
                botonesInfo.Add(buttonInfo);
            }
            //Se convierte la lista botonesInfo a formato JSON usando JsonConvert.SerializeObject
            /*
             JsonConvert.SerializeObject(botonesInfo, Formatting.Indented); uso:
            Serializar toda la lista botonesInfo en una cadena JSON.
            Contexto: Después de que se ha completado la recopilación de toda la información de los botones y sus mesas asociadas,
            se serializa la lista completa botonesInfo a una cadena JSON. Esta cadena JSON representa el estado completo de los
            botones y sus asociaciones con mesas.
            Resultado: Toda la información sobre los botones y las mesas se convierte en una cadena JSON, que luego se guardará en un archivo
             */
            var botonesJson = JsonConvert.SerializeObject(botonesInfo, Formatting.Indented);
            //Se construye la ruta completa del archivo donde se guardará el JSON
            /*
             Path.Combine uso: Combinar partes de una ruta de archivo en una ruta completa En este caso, Path.GetDirectoryName
            (filePath) obtiene el directorio de la ruta proporcionada por filePath, y filePath representa el nombre del archivo.
            Resultado: Se obtiene una ruta completa al archivo que se utilizará para guardar el JSON
             */
            var botonesFilePath = Path.Combine(Path.GetDirectoryName(filePath), filePath);
            //Se escribe el JSON en el archivo especificado por filePath usando File.WriteAllText
            File.WriteAllText(botonesFilePath, botonesJson);
        }


        
        public static void LoadDataEditing(string filePath, Dictionary<Button, Mesa> informacionMesas, Control.ControlCollection controls, Dictionary<string, Color> colores, ContextMenuStrip contextMenuStrip, Panel largePanel, TableLayoutPanel tableLayoutPanel)
        {
            
            string directoryPath = Path.GetDirectoryName(filePath);


            var botonesFilePath = Path.Combine(directoryPath, filePath);
            List<Dictionary<string, object>> botonesInfo = null;
            if (File.Exists(botonesFilePath))
            {
                var botonesJson = File.ReadAllText(botonesFilePath);
                //Deserializa la cadena JSON (botonesJson) en una lista de diccionarios (botonesInfo). Cada diccionario representa
                //la información de un botón y sus propiedades almacenadas como pares clave-valor.
                botonesInfo = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(botonesJson);
            }

            if (botonesInfo != null)
            {
                controls.Clear();
                informacionMesas.Clear();

                foreach (var buttonInfo in botonesInfo)
                {
                    Button nuevoElemento;

                    // Verifica el tipo de botón y crea la instancia adecuada
                    /*
                     Este bloque de código verifica el tipo de botón almacenado en el diccionario buttonInfo y crea una instancia
                    del tipo adecuado.
                    Primero, se verifica si el diccionario buttonInfo contiene la clave "Tipo". Esto asegura que hay información
                    sobre el tipo de botón.
                    Comparación del tipo: Si la clave "Tipo" está presente, se compara el valor asociado con el tipo RoundButton 
                    convertido a una cadena (typeof(RoundButton).ToString()
                    Si el tipo coincide con RoundButton, se crea una nueva instancia de RoundButton. De lo contrario, se crea una
                    instancia de Button
                     */
                    if (buttonInfo.ContainsKey("Tipo") && buttonInfo["Tipo"].ToString() == typeof(RoundButton).ToString())
                    {
                        nuevoElemento = new RoundButton();
                    }
                    else
                    {
                        nuevoElemento = new Button();
                    }

                    // Configura las propiedades del botón
                    nuevoElemento.Text = buttonInfo["Text"].ToString();
                    nuevoElemento.Tag = buttonInfo["Tag"].ToString();
                    /*
                     asigna el tamaño (ancho y alto) al nuevo botón nuevoElemento utilizando la información almacenada en buttonInfo
                    Por qué se usa Convert.ToInt32?     
                    Robustez: Convert.ToInt32 puede manejar valores nulos, devolviendo 0 si el valor es null, mientras que int.Parse
                    lanzará una excepción si el valor es null.
                    Conversión más segura: Convert.ToInt32 es generalmente más seguro en términos de manejo de errores y valores nulos.
                    Antes de la conversión, los valores almacenados en el diccionario buttonInfo bajo las claves "Ancho" y "Alto" 
                    son de tipo object. Este tipo puede contener cualquier valor, pero en el contexto del código, estos valores 
                    suelen ser de tipo string
                     */
                    nuevoElemento.Size = new Size(Convert.ToInt32(buttonInfo["Ancho"]), Convert.ToInt32(buttonInfo["Alto"]));

                    // Asigna el color de fondo si está definido en el diccionario de colores
                    if (colores.ContainsKey(nuevoElemento.Tag.ToString()))
                    {
                        nuevoElemento.BackColor = colores[nuevoElemento.Tag.ToString()];
                    }

                    // Obtiene la ubicación del botón y la asigna
                    /*
                     (JObject)buttonInfo["Location"] convierte este valor a un objeto JSON (JObject). Esta conversión es necesaria
                    para poder acceder a las propiedades X y Y dentro del objeto JSON.
                     */
                    var locationInfo = (JObject)buttonInfo["Location"];
                    /*
                     Una vez convertido a JObject, se pueden acceder las propiedades X y Y para crear un nuevo Point que representa
                    la ubicación del botón.
                     */
                    Point location = new Point(locationInfo["X"].ToObject<int>(), locationInfo["Y"].ToObject<int>());
                    nuevoElemento.Location = location;

                    // Si hay información de mesa asociada, la deserializa y la asocia al botón correspondiente
                    if (buttonInfo.ContainsKey("MesaInfo") && buttonInfo["MesaInfo"] != null)
                    {
                        /*
                         En este bloque de código, se deserializa la información asociada a la mesa y se la añade al diccionario 
                        informacionMesas. deserializa esta cadena JSON en un objeto de tipo Mesa

                         */
                        var mesaInfo = JsonConvert.DeserializeObject<Mesa>(buttonInfo["MesaInfo"].ToString());
                        //informacionMesas.Add(nuevoElemento, mesaInfo) agrega el nuevo botón y su información de mesa asociada al diccionario informacionMesas
                        informacionMesas.Add(nuevoElemento, mesaInfo);
                    }

                    // Actualiza el número total de mesas si está presente en los datos cargados
                    if (buttonInfo.ContainsKey("Total Mesas") && buttonInfo["Total Mesas"] != null)
                    {
                        Mesa.TotalMesas = Convert.ToInt32(buttonInfo["Total Mesas"]);
                    }

                    // Crea una instancia de MoverBotones para manejar la interacción del botón con los paneles
                    MoverBotones moverBotones = new MoverBotones(nuevoElemento, largePanel, tableLayoutPanel);

                    // Asigna el menú contextual al botón
                    nuevoElemento.ContextMenuStrip = contextMenuStrip;

                    // Agrega el botón reconstruido a la colección de controles y lo trae al frente
                    controls.Add(nuevoElemento);
                    nuevoElemento.BringToFront();
                }
            }
        }

        //es responsable de cargar datos previamente guardados en formato JSON desde un archivo, y luego reconstruir y configurar
        //los botones (que representan mesas en un restaurante) junto con su información asociada en la interfaz gráfica de usuario.
        public static void LoadData(string filePath, Dictionary<Button, Mesa> informacionMesas, Control.ControlCollection controls, Dictionary<string, Color> colores, ContextMenuStrip contextMenuStrip, Panel largePanel, TableLayoutPanel tableLayoutPanel)
        {
            //Path.GetDirectoryName(filePath): Extrae la ruta del directorio del archivo filePath
            string directoryPath = Path.GetDirectoryName(filePath);
            //Path.Combine(directoryPath, filePath): Combina el directorio obtenido con filePath para obtener la ruta completa del
            //archivo JSON que contiene la información de los botones
            var botonesFilePath = Path.Combine(directoryPath, filePath);
            List<Dictionary<string, object>> botonesInfo = null;
            //Verifica si el archivo JSON existe en la ruta botonesFilePath
            if (File.Exists(botonesFilePath))
            {
                var botonesJson = File.ReadAllText(botonesFilePath); //Lee todo el contenido del archivo JSON como una cadena.
                //Deserializa la cadena JSON (botonesJson) en una lista de diccionarios (botonesInfo). Cada diccionario representa
                //la información de un botón y sus propiedades.
                botonesInfo = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(botonesJson);
            }

            //Reconstrucción de los botones y configuración de la interfaz gráfica
            if (botonesInfo != null)
            {
                //elimina todos los botones existentes en la colección controls antes de cargar los nuevos botones desde el archivo
                controls.Clear();
                //elimina todas las entradas existentes en el diccionario informacionMesas antes de cargar las nuevas asociaciones
                //botón-mesa desde el archivo.
                informacionMesas.Clear();

                //teración sobre botonesInfo: Para cada diccionario buttonInfo en la lista botonesInfo (que representa la
                //información de cada botón guardado):
                foreach (var buttonInfo in botonesInfo)
                {
                    Button nuevoElemento;
                    //Dependiendo del tipo de botón almacenado en buttonInfo["Tipo"], se crea un nuevo Button o RoundButton
                    if (buttonInfo.ContainsKey("Tipo") && buttonInfo["Tipo"].ToString() == typeof(RoundButton).ToString())
                    {
                        nuevoElemento = new RoundButton();
                    }
                    else
                    {
                        nuevoElemento = new Button();
                    }

                    //Se establecen las propiedades del botón como Text, Tag, Size, y se ajusta el color de fondo si está definido
                    //en el diccionario colores
                    nuevoElemento.Text = buttonInfo["Text"].ToString();
                    nuevoElemento.Tag = buttonInfo["Tag"].ToString();
                    nuevoElemento.Size = new Size(Convert.ToInt32(buttonInfo["Ancho"]), Convert.ToInt32(buttonInfo["Alto"]));

                    if (colores.ContainsKey(nuevoElemento.Tag.ToString()))
                    {
                        nuevoElemento.BackColor = colores[nuevoElemento.Tag.ToString()];
                    }

                    //Se recupera la ubicación del botón (Location) desde buttonInfo["Location"] y se asigna al nuevo botón.
                    var locationInfo = (JObject)buttonInfo["Location"];
                    Point location = new Point(locationInfo["X"].ToObject<int>(), locationInfo["Y"].ToObject<int>());
                    nuevoElemento.Location = location;

                    //Si buttonInfo contiene información de mesa ("MesaInfo"), se deserializa esta información en un objeto Mesa y
                    //se añade al diccionario informacionMesas, asociado con el nuevo botón
                    if (buttonInfo.ContainsKey("MesaInfo") && buttonInfo["MesaInfo"] != null)
                    {
                        var mesaInfo = JsonConvert.DeserializeObject<Mesa>(buttonInfo["MesaInfo"].ToString());
                        informacionMesas.Add(nuevoElemento, mesaInfo);
                    }
                    //Si buttonInfo contiene "Total Mesas", se actualiza la propiedad estática TotalMesas de la clase Mesa con el
                    //valor correspondiente
                    if (buttonInfo.ContainsKey("Total Mesas") && buttonInfo["Total Mesas"] != null)
                    {
                        Mesa.TotalMesas = Convert.ToInt32(buttonInfo["Total Mesas"]);
                    }

                    //Se asigna el menú contextual (contextMenuStrip) al nuevo botón.
                    nuevoElemento.ContextMenuStrip = contextMenuStrip;
                    //El nuevo botón se agrega a la colección controls y se coloca en el frente (BringToFront()) para asegurarse de
                    //que esté visible correctamente en la interfaz gráfica.
                    controls.Add(nuevoElemento);
                    nuevoElemento.BringToFront();
                }
            }
        }

    }

}