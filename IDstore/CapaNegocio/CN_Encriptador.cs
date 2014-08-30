using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importados
using System.Security.Cryptography;
using System.IO;
namespace CapaNegocio
{
    class CN_Encriptador
    {

        public String EncriptarPasword(string pasword)
        {

            int keySize = 32;
            int ivSize = 16;

            // Solicitar al usuario la clave, el vector de inicio y el mensaje a ser cifrado


            string strKey = "Llave12345";

            string strIv = "Vector12345";


            string strMsg = pasword;


            /////////////////////////////////////////////////////////////////////////////////////


            // Convertir la llave y el vector de inicio a su representación en bytes

            byte[] key = UTF8Encoding.UTF8.GetBytes(strKey);
            byte[] iv = UTF8Encoding.UTF8.GetBytes(strIv);

            // Garantizar el tamaño correcto de la clave y el vector de inicio
            // mediante substring o padding

            Array.Resize<byte>(ref key, keySize);
            Array.Resize<byte>(ref iv, ivSize);


            // Cifrar/descifrar el mensaje como cadena de texto

            string encrypted = encryptString(strMsg, key, iv);

            //  string decrypted = decryptString(encrypted, key, iv);

            // Mostrar al usuario los resultados obtenidos durante el proceso


            /////////////////////////////////////////////////////////////////////////////////////

            return encrypted;

        }

        public String DesencriptarPasword(string PaswordEncrypted)
        {

            int keySize = 32;
            int ivSize = 16;

            // Solicitar al usuario la clave, el vector de inicio y el mensaje a ser cifrado


            string strKey = "Llave12345";

            string strIv = "Vector12345";


            // string strMsg = pasword;


            /////////////////////////////////////////////////////////////////////////////////////


            // Convertir la llave y el vector de inicio a su representación en bytes

            byte[] key = UTF8Encoding.UTF8.GetBytes(strKey);
            byte[] iv = UTF8Encoding.UTF8.GetBytes(strIv);

            // Garantizar el tamaño correcto de la clave y el vector de inicio
            // mediante substring o padding

            Array.Resize<byte>(ref key, keySize);
            Array.Resize<byte>(ref iv, ivSize);


            // Cifrar/descifrar el mensaje como cadena de texto

            // string encrypted = encryptString(strMsg, key, iv);

            string decrypted = decryptString(PaswordEncrypted, key, iv);

            // Mostrar al usuario los resultados obtenidos durante el proceso


            /////////////////////////////////////////////////////////////////////////////////////

            return decrypted;

        }



        public void xxx(string STRKEY, string STRIV, string STRMSG)
        {


            // Definir el tamaño de la clave y el vector de inicio a utilizarse

            int keySize = 32;
            int ivSize = 16;

            // Solicitar al usuario la clave, el vector de inicio y el mensaje a ser cifrado



            Console.Write("Key:\t");
            string strKey = Console.ReadLine();

            Console.Write("Iv:\t");
            string strIv = Console.ReadLine();

            Console.Write("Message:\t");
            string strMsg = Console.ReadLine();

            // Convertir la llave y el vector de inicio a su representación en bytes

            byte[] key = UTF8Encoding.UTF8.GetBytes(strKey);
            byte[] iv = UTF8Encoding.UTF8.GetBytes(strIv);

            // Garantizar el tamaño correcto de la clave y el vector de inicio
            // mediante substring o padding

            Array.Resize<byte>(ref key, keySize);
            Array.Resize<byte>(ref iv, ivSize);

            try
            {
                /////////////////////////////////////////////////////////////////////////////////////

                // Cifrar/descifrar el mensaje como cadena de texto

                string encrypted = encryptString(strMsg, key, iv);

                string decrypted = decryptString(encrypted, key, iv);

                // Mostrar al usuario los resultados obtenidos durante el proceso

                Console.WriteLine("Encrypted #1: [" + encrypted + "]");
                Console.WriteLine("Decrypted #1: [" + decrypted + "]");

                /////////////////////////////////////////////////////////////////////////////////////

                // Nombre del archivo donde se almacenará el mensaje cifrado,
                // ubicado en el mismo directorio de la aplicación

                string filename = "demo.data";

                // Cifrar/descifrar el mensaje en un archivo

                encryptToFile(strMsg, filename, key, iv);

                decrypted = decryptFromFile(filename, key, iv);

                // Mostrar al usuario el resultado obtenido durante el proceso

                Console.WriteLine("Decrypted #2: [" + decrypted + "]");

                /////////////////////////////////////////////////////////////////////////////////////
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
        /**
        * Cifra una cadena texto con el algoritmo de Rijndael
        * 
        * @param	plainMessage	mensaje plano (sin cifrar)
        * @param	Key				clave del cifrado para Rijndael
        * @param	IV				vector de inicio para Rijndael
        * @return	string			texto cifrado
        */

        public static string encryptString(String plainMessage, byte[] Key, byte[] IV)
        {
            // Crear una instancia del algoritmo de Rijndael

            Rijndael RijndaelAlg = Rijndael.Create();

            // Establecer un flujo en memoria para el cifrado

            MemoryStream memoryStream = new MemoryStream();

            // Crear un flujo de cifrado basado en el flujo de los datos

            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         RijndaelAlg.CreateEncryptor(Key, IV),
                                                         CryptoStreamMode.Write);

            // Obtener la representación en bytes de la información a cifrar

            byte[] plainMessageBytes = UTF8Encoding.UTF8.GetBytes(plainMessage);

            // Cifrar los datos enviándolos al flujo de cifrado

            cryptoStream.Write(plainMessageBytes, 0, plainMessageBytes.Length);

            cryptoStream.FlushFinalBlock();

            // Obtener los datos datos cifrados como un arreglo de bytes

            byte[] cipherMessageBytes = memoryStream.ToArray();

            // Cerrar los flujos utilizados

            memoryStream.Close();
            cryptoStream.Close();

            // Retornar la representación de texto de los datos cifrados

            return Convert.ToBase64String(cipherMessageBytes);
        }

        /**
         * Descifra una cadena texto con el algoritmo de Rijndael
         * 
         * @param	encryptedMessage	mensaje cifrado
         * @param	Key					clave del cifrado para Rijndael
         * @param	IV					vector de inicio para Rijndael
         * @return	string				texto descifrado (plano)
         */

        public static string decryptString(String encryptedMessage, byte[] Key, byte[] IV)
        {
            // Obtener la representación en bytes del texto cifrado

            byte[] cipherTextBytes = Convert.FromBase64String(encryptedMessage);

            // Crear un arreglo de bytes para almacenar los datos descifrados

            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            // Crear una instancia del algoritmo de Rijndael			

            Rijndael RijndaelAlg = Rijndael.Create();

            // Crear un flujo en memoria con la representación de bytes de la información cifrada

            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            // Crear un flujo de descifrado basado en el flujo de los datos

            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         RijndaelAlg.CreateDecryptor(Key, IV),
                                                         CryptoStreamMode.Read);

            // Obtener los datos descifrados obteniéndolos del flujo de descifrado

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            // Cerrar los flujos utilizados

            memoryStream.Close();
            cryptoStream.Close();

            // Retornar la representación de texto de los datos descifrados

            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////		
        ////////////////////////////////////////////////////////////////////////////////////////////		

        /**
         * Cifra una cadena texto con el algoritmo de Rijndael y lo almacena en un archivo
         * 
         * @param	plainMessage	mensaje plano (sin cifrar)
         * @param	filename		nombre del archivo donde se almacenará el mensaje cifrado
         * @param	Key				clave del cifrado para Rijndael
         * @param	IV				vector de inicio para Rijndael
         * @return	void
         */

        public static void encryptToFile(String plainMessage, String filename, byte[] Key, byte[] IV)
        {
            // Crear un flujo para el archivo a generarse

            FileStream fileStream = File.Open(filename, FileMode.OpenOrCreate);

            // Crear una instancia del algoritmo Rijndael

            Rijndael RijndaelAlg = Rijndael.Create();

            // Crear un flujo de cifrado basado en el flujo de los datos

            CryptoStream cryptoStream = new CryptoStream(fileStream,
                                                         RijndaelAlg.CreateEncryptor(Key, IV),
                                                         CryptoStreamMode.Write);

            // Crear un flujo de escritura basado en el flujo de cifrado

            StreamWriter streamWriter = new StreamWriter(cryptoStream);

            // Cifrar el mensaje a través del flujo de escritura

            streamWriter.WriteLine(plainMessage);

            // Cerrar los flujos utilizados

            streamWriter.Close();
            cryptoStream.Close();
            fileStream.Close();
        }

        /**
         * Descifra el contenido de un archivo con el algoritmo de Rijndael y lo retorna
         * como una cadena de texto plano
         * 
         * @param	filename		nombre del archivo donde se encuentra el mensaje cifrado
         * @param	Key				clave del cifrado para Rijndael
         * @param	IV				vector de inicio para Rijndael
         * @return	string			mensaje descifrado (plano)
         */

        public static string decryptFromFile(String filename, byte[] Key, byte[] IV)
        {
            // Crear un flujo para el archivo a generarse

            FileStream fileStream = File.Open(filename, FileMode.OpenOrCreate);

            // Crear una instancia del algoritmo Rijndael

            Rijndael RijndaelAlg = Rijndael.Create();

            // Crear un flujo de cifrado basado en el flujo de los datos

            CryptoStream cryptoStream = new CryptoStream(fileStream,
                                                         RijndaelAlg.CreateDecryptor(Key, IV),
                                                         CryptoStreamMode.Read);

            // Crear un flujo de lectura basado en el flujo de cifrado

            StreamReader streamReader = new StreamReader(cryptoStream);

            // Descifrar el mensaje a través del flujo de lectura

            string plainMessage = streamReader.ReadLine();

            // Cerrar los flujos utilizados

            streamReader.Close();
            cryptoStream.Close();
            fileStream.Close();

            return plainMessage;
        }

    }
}
