using System;
using System.Runtime.InteropServices;

namespace SbBjT.Bussines.ReleaseCore
{
    public class ReleaseCd : IRelease
    {
        public ReleaseCd(string leter)
        {
            Leter = leter;
        }

        public string Leter { get; set; }

        public void Release()
        {
            Expulsar(Leter);
        }

        //Constantes usadas en la API 
        /// <summary>Indica que se se hara lectura genérica del archvo</summary>
        const uint GENERICREAD = 0x80000000;
        /// <summary>Indica que se debe abrir un archivo existente, no crear uno nuevo</summary>
        const uint OPENEXISTING = 3;
        /// <summary>Comando enviado al dispositivo para abrir la puerta</summary>
        const uint IOCTL_STORAGE_EJECT_MEDIA = 0x2D4808;
        /// <summary>Indica que la operaciónj no finalizo adecuadamente </summary>
        const int INVALID_HANDLE = -1;


        /// <summary>Puntero que se usara para apuntar al archivo (unidad) de CDRom</summary>
        private static IntPtr fileHandle;
        /// <summary>Indica el número de bytes leidos cmo rspuesta de un proceso</summary>
        private static uint returnedBytes;

        /// <summary>
        /// esta función sirve para crear archivos pero también para abrir archivos existentes, 
        /// así que se utilizará para abrir un archivo, la unidad del CD hace parte del sistema 
        /// global de archivos así que podemos llegar a ella desde este medio
        /// </summary>
        /// <returns>Puntero que sirve como manejador del archivo</returns>
        [DllImport("kernel32", SetLastError = true)]
        static extern IntPtr CreateFile(string fileName,
                                        uint desiredAccess,
                                        uint shareMode,
                                        IntPtr attributes,
                                        uint creationDisposition,
                                        uint flagsAndAttributes,
                                        IntPtr templateFile);

        /// <summary>
        /// Cierra un manejador a un objeto, 
        /// en este caso el objeto será la unidad de CD que hemos accedido a través de CreateFile 
        /// </summary>
        /// <param name="driveHandle" />
        /// <returns>Entero que indica la respuesta del proceso</returns>
        [DllImport("kernel32", SetLastError = true)]
        static extern int CloseHandle(IntPtr driveHandle);


        /// <summary>
        /// Nos permite enviar comandos de I/O a un dispositivo. 
        /// </summary>
        /// <returns>Indica si fue o no enviado el comando al dispositivo</returns>
        [DllImport("kernel32", SetLastError = true)]
        static extern bool DeviceIoControl(IntPtr driveHandle,
                                            uint IoControlCode,
                                            IntPtr lpInBuffer,
                                            uint inBufferSize,
                                            IntPtr lpOutBuffer,
                                            uint outBufferSize,
                                            ref uint lpBytesReturned,
                                            IntPtr lpOverlapped);

        /// <summary>   
        /// Expulsa el drive de acuerdo a la letra asignada   
        /// </summary>   
        /// <param name="driveLetter" />Letra del drive   
        public static void Expulsar(string driveLetter)
        {
            //Modificar el nombre de la unidad de acuerdo a como lo entiende el 
            //sistema de archivos
            driveLetter = @"\\.\" + driveLetter.Substring(0, 2);
            try
            {
                //Crea el puntero al archivo (dispositivo)   
                fileHandle = CreateFile(driveLetter, GENERICREAD, 0,
                                        IntPtr.Zero, OPENEXISTING,
                                        0, IntPtr.Zero);

                //Si es una unidad valida   
                if (fileHandle.ToInt32() != INVALID_HANDLE)
                {
                    //Intenta expulsar el dispositivo   
                    DeviceIoControl(fileHandle, IOCTL_STORAGE_EJECT_MEDIA,
                                    IntPtr.Zero, 0, IntPtr.Zero, 0,
                                    ref returnedBytes, IntPtr.Zero);
                }
            }
            catch
            {
                //Sino lo pudo expulsar   
                throw new Exception(Marshal.GetLastWin32Error().ToString());
            }
            finally
            {
                //Asegurarse de siempre cerrar el puntero del archvo   
                CloseHandle(fileHandle);
                fileHandle = IntPtr.Zero;
            }
        }
    }
}
