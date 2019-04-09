using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Entidades
{
    public class Imagen
    {
        private static Imagen instance;
        public int originalHeight = 0;
        public int originalWidth = 0;
        public float imgDpiX;
        public float imgDpiY;
        public double originalCmHeight = 0;
        public double originalCmWidth = 0;
        public float porcentajeDisminuido = 0;
        private Imagen() { }

        public static Imagen Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Imagen();
                }
                return instance;
            }
        }
        public string nombreArchivo { get; set; }
        public string ruta { get; set; }
        public string rutaEdit { get; set; }
        public Bitmap bitmap { get; set; }
        public string nombreArchivoEditado { get; set; }
        public int umbral { get; set; }
        public String GuardarImagen(FileUpload FileUploadPlanta)
        {

            nombreArchivo = DateTime.Now.Ticks.ToString() + FileUploadPlanta.FileName;
            // rutaEdit = "~/img/";
            ruta = "~/img/" + nombreArchivo;
            FileUploadPlanta.SaveAs(System.Web.HttpContext.Current.Server.MapPath(ruta));//sube la img 
            return ruta;
        }

        public Bitmap ConvertirBlancoNegro(Bitmap source, int umb, bool pieIzquierdo)
        {
            umbral = umb;
            // Bitmap con la imagen binaria
            Bitmap target = new Bitmap(source.Width, source.Height, source.PixelFormat);
            Bitmap targetRotate = new Bitmap(source.Width, source.Height, source.PixelFormat);
            // Recorrer pixel de la imagen
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    // Color del pixel
                    Color col = source.GetPixel(i, j);
                    // Escala de grises
                    byte gray = (byte)(col.R * 0.3f + col.G * 0.59f + col.B * 0.11f);
                    // Blanco o negro
                    byte value = 0;
                    if (gray > umb || (col.R == 0 && col.G == 0 && col.B == 0 && col.A == 0))
                    {
                        value = 255;
                    }
                    // Asginar nuevo color
                    Color newColor = System.Drawing.Color.FromArgb(value, value, value);
                    target.SetPixel(i, j, newColor);
                    //voltea la imagen para pie izquierdo
                    targetRotate.SetPixel(target.Width - 1 - i, j, newColor);
                }
            }
            //lo que se guarda
            if (pieIzquierdo)
            {
                bitmap = targetRotate;
            }
            else
            {
                bitmap = target;
            }


            guardarImgeEdit();
            return target;
        }
        public Bitmap ConvertirBlancoNegro(Bitmap source, int umb)
        {
            umbral = umb;
            // Bitmap con la imagen binaria
            Bitmap target = new Bitmap(source.Width, source.Height, source.PixelFormat);
            // Bitmap targetRotate = new Bitmap(source.Width, source.Height, source.PixelFormat);
            // Recorrer pixel de la imagen
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    // Color del pixel
                    Color col = source.GetPixel(i, j);/*
                    System.Diagnostics.Debug.WriteLine("R:" +col.R);
                    System.Diagnostics.Debug.WriteLine("G:" + col.G);
                    System.Diagnostics.Debug.WriteLine("B:" + col.B);
                    System.Diagnostics.Debug.WriteLine("B:" + col.A);*/
                    // Escala de grises
                    byte gray = (byte)(col.R * 0.3f + col.G * 0.59f + col.B * 0.11f);
                    // Blanco o negro
                    byte value = 0;
                    if (gray > umb || (col.R == 0 && col.G == 0 && col.B == 0 && col.A == 0))
                    {
                        value = 255;
                    }
                    // Asginar nuevo color
                    Color newColor = System.Drawing.Color.FromArgb(value, value, value);
                    target.SetPixel(i, j, newColor);
                    //voltea la imagen para pie izquierdo
                    //   targetRotate.SetPixel(target.Width - 1 - i, j, newColor);
                }
            }
            //lo que se guarda
            bitmap = target;

            return target;
        }

        public Bitmap getBitMap()
        {
            String rutaImgOriginalImagen = System.Web.HttpContext.Current.Server.MapPath("~/img/") + nombreArchivo;
            Bitmap bitmap = new Bitmap(rutaImgOriginalImagen);

            return bitmap;

        }
        public Bitmap getBitMap(String nombre)
        {
            String rutaImgOriginalImagen = System.Web.HttpContext.Current.Server.MapPath("~/img/") + nombre;
            Bitmap bitmap = new Bitmap(rutaImgOriginalImagen);
            System.Diagnostics.Debug.WriteLine(" original Width:" + bitmap.Width);
            System.Diagnostics.Debug.WriteLine(" original Height:" + bitmap.Height);
            return bitmap;

        }
        public void guardarImgeEdit()
        {
            String nombreEditAnterior = nombreArchivoEditado;//guardo nombre del archivo anterior
            nombreArchivoEditado = DateTime.Now.Ticks.ToString() + nombreArchivo;
            String rutaEdi = System.Web.HttpContext.Current.Server.MapPath("~/img/") + nombreArchivoEditado;//ruta almacenamiento en server
            rutaEdit = "~/img/" + nombreArchivoEditado;//ruta para mostrar en Web
            bitmap.Save(rutaEdi);
            //borra la anterior imagen editada
            borrarImagenEdit(nombreEditAnterior);

        }
        public void guardarImgeEdit(String nameAnterior, String dataImgBase64, int umbral)
        {
            bitmap = base64ToBitmap(dataImgBase64);
            bitmap = ConvertirBlancoNegro(bitmap, umbral);
            String nombreEditAnterior = nameAnterior;//guardo nombre del archivo anterior
            nombreArchivoEditado = DateTime.Now.Ticks.ToString() + nombreArchivo;
            String rutaEdi = System.Web.HttpContext.Current.Server.MapPath("~/img/") + nombreArchivoEditado;//ruta almacenamiento en server
            rutaEdit = "~/img/" + nombreArchivoEditado;//ruta para mostrar en Web
            bitmap.Save(rutaEdi);
            //borra la anterior imagen editada
            borrarImagenEdit(nombreEditAnterior);

        }
        public Bitmap base64ToBitmap(String base64Img)
        {
            Bitmap bmpReturn = null;
            byte[] byteBuffer = Convert.FromBase64String(base64Img);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);
            memoryStream.Position = 0;
            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);
            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;
            return bmpReturn;
        }

        public void borrarImagenEdit(String name)
        {
            //borra un archivo
            if (name != null && name != "")
            {
                try
                {
                    System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath("~/img/") + name);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(" error al eliminar" + ex.Message);

                }


            }
        }

        public Bitmap voltearImagenResultado(Bitmap source)
        {
            Bitmap targetRotate = new Bitmap(source.Width, source.Height, source.PixelFormat);
            // Recorrer pixel de la imagen
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    // Color del pixel
                    Color col = source.GetPixel(i, j);

                    //voltea la imagen para pie izquierdo
                    targetRotate.SetPixel(source.Width - 1 - i, j, col);
                }
            }
            return targetRotate;
        }
        //hace que la imagen sea pequeña para que con consuma mucha memoria
        public Bitmap cambiarTamano(Bitmap bitmap)
        {
            int maxWidth = 600;//el maximo tamaño a tener en width 
            int maxHeight = 800;//maximo tamaño a tener en height 
            originalHeight = bitmap.Height;
            originalWidth = bitmap.Width;
            int width = originalWidth;
            int height = originalHeight;
            float disminuir = 1;
            do
            {
                disminuir -= 0.05f;
                width = Convert.ToInt32(bitmap.Width - bitmap.Width * disminuir);
                height = Convert.ToInt32(bitmap.Height - bitmap.Height * disminuir);

            }
            while (((maxHeight >= height) && (maxWidth >= width)) && (disminuir >= 0));
            //pone el porcentaje que disminuje
            if (disminuir >= 0)
            {
                porcentajeDisminuido = disminuir;
            }



            Bitmap newImg = new Bitmap(bitmap, width, height);
            //dpi test-------------------------------------------
            imgDpiX = bitmap.HorizontalResolution;
            imgDpiY = bitmap.VerticalResolution;
            newImg.SetResolution(imgDpiX, imgDpiY);//pone la resolucion del original

            originalCmWidth = pixelToCentimetros(bitmap.Width, imgDpiX);
            originalCmHeight = pixelToCentimetros(bitmap.Width, imgDpiY);

            //  System.Diagnostics.Debug.WriteLine("original tamaño" + imgDpiX + "<->" + imgDpiY + "-" + disminuir + "<->" + originalCmWidth);

            //  System.Diagnostics.Debug.WriteLine("nuevo tamaño" + imgDpiX + "<->" + imgDpiY + "-" + disminuir + "<->" + optenerCentimetrosRealesWidht(pixelToCentimetros(newImg.Width, imgDpiX)));
            //
            //resDpiX = newImg.HorizontalResolution;
            //resDpiY = newImg.VerticalResolution;
            //System.Diagnostics.Debug.WriteLine("nuevo tamaño" + resDpiX + "<->" + resDpiY + "-" + disminuir + "<->" + pixelToCentimetros(newImg.Width, resDpiX));

            return newImg;

        }

        public double pixelToCentimetros(int pixelLength, double dpi)
        {
            // Pulgadas x DPI = Píxeles
            //Píxeles / DPI = Pulgadas
            double centimetros = (pixelLength * 2.54) / dpi;
            // centimetros += porcentajeDisminuido * centimetros;
            return centimetros;
        }

        public double optenerCentimetrosRealesWidht(double centimetro)
        {
            if (centimetro <= 0)
                return 0;
            else
                return centimetro += originalCmWidth * porcentajeDisminuido;
        }

        public double optenerCentimetrosRealesHeight(double centimetro)
        {
            return centimetro += originalCmHeight * porcentajeDisminuido;
        }

        public double optenerCentimetrosIA(double IApixeles, FormatoA formatoA4)
        {
            System.Diagnostics.Debug.WriteLine(" IA pixel:" + IApixeles);
            double res = 0;
            /*  double areaPixeles = originalHeight * originalWidth;
              double valorPixelCm = (1 * formatoA4.getArea()) / areaPixeles;
              System.Diagnostics.Debug.WriteLine(" valor px:" + valorPixelCm);
              System.Diagnostics.Debug.WriteLine(" porcentajeDisminuido :" + porcentajeDisminuido);
              res = valorPixelCm * (IApixeles + (IApixeles * porcentajeDisminuido));
              */
              double dis= (IApixeles * porcentajeDisminuido);
            res = IApixeles;
            if (dis>0) {
                res += dis;
            }
            System.Diagnostics.Debug.WriteLine(" IA:" + res);
            return res;
        }
        public double optenerCentimetrosHeight(double pxHeigth, FormatoA formatoA4)
        {
            double res = 0;
            double valorPixel = (1 * formatoA4.height) / originalHeight;
            res = valorPixel * (pxHeigth + (pxHeigth * porcentajeDisminuido));
            return res;
        }
        public double optenerCentimetrosWidth(double pxWidth, FormatoA formatoA4)
        {
            double res = 0;
            double valorPixel = (1 * formatoA4.width) / originalWidth;
            res = valorPixel * (pxWidth + (pxWidth * porcentajeDisminuido));
            return res;
        }
        //mostrar resultado en el tamaño original
        public void convertirToOriginalSize()
        {
            Bitmap newBitmap = new Bitmap(bitmap, originalWidth, originalHeight);
            bitmap = newBitmap;
        }

    }

}
