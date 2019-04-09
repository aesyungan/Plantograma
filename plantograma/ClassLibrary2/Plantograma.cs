using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Entidades
{
    public class Plantograma
    {

        public float resultado { get; set; }
        public int talon { get; set; }
        public int espacioInterno { get; set; }
        public int mf { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int ai { get; set; }
        public double IA { get; set; }
        public int longitudPieY { get; set; }
        public int longitudPieX { get; set; }
        public Plantograma()
        {
            // this.formatoA4 = new FormatoA(21f, 29.7f);//tamaño de la hoja
        }
        public Bitmap analizarImagen(Bitmap source)
        {

            Pixel pixelTop = new Pixel(0, 0);
            Pixel pixelBottom = new Pixel(0, 0);
            Pixel pixelLeft = new Pixel(0, 0);
            Pixel pixelRight = new Pixel(0, 0);
            bool primero = false;
            bool segundo = false;
            //datos iniciales
            System.Diagnostics.Debug.WriteLine("Ancho X " + source.Height);
            System.Diagnostics.Debug.WriteLine("Ancho Y " + source.Height);
            //ancho de metatarzo

            // Recorrer pixel de la imagen para top y bottom
            for (int i = 0; i < source.Height; i++)
            {
                for (int j = 0; j < source.Width; j++)
                {
                    if (pixelValido(source, j, i, source.Width, source.Height))
                    {

                        //top
                        if (primero == false)//toptiene el primer pixel valido dede el eje y
                        {
                            pixelTop.x = j;
                            pixelTop.y = i;
                            primero = true;


                            //Color newColor = System.Drawing.Color.FromArgb(0, 123, 255);//pongo de color azul
                            //source.SetPixel(j, i, newColor);

                        }
                        //bottom  //ultimo pixel yalido desde eje y
                        pixelBottom.x = j;
                        pixelBottom.y = i;
                    }
                }
            }
            // Recorrer pixel de la imagen para left  y right
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    if (pixelValido(source, i, j, source.Width, source.Height))
                    {

                        //top
                        if (segundo == false)//toptiene el primer pixel valido dede el eje y
                        {
                            pixelLeft.x = i;
                            pixelLeft.y = j;
                            segundo = true;


                            //Color newColor = System.Drawing.Color.FromArgb(0, 123, 255);//pongo de color azul
                            //source.SetPixel(j, i, newColor);

                        }
                        //bottom  //ultimo pixel yalido desde eje y
                        pixelRight.x = i;
                        pixelRight.y = j;
                    }
                }
            }
            //dibijar top
            dibujarPunto(source, pixelTop.x, pixelTop.y, System.Drawing.Color.Red);
            //dibujar boottom
            dibujarPunto(source, pixelBottom.x, pixelBottom.y, System.Drawing.Color.Yellow);
            //dibujar left
            dibujarPunto(source, pixelLeft.x, pixelLeft.y, System.Drawing.Color.Brown);
            //dibujar Right
            dibujarPunto(source, pixelRight.x, pixelRight.y, System.Drawing.Color.Chocolate);
            //punto 1
            bool punto1 = false;
            Pixel puntoUno = new Pixel(0, 0);
            for (int i = pixelLeft.x; i <= pixelRight.x; i++)
            {
                //0.34 o 0.39 max
                for (int j = Convert.ToInt32(((source.Height / 2) * 0.39f)); j < source.Height / 2; j++)

                {
                    if (pixelValido(source, i, j, source.Width, source.Height))
                    {

                        //top
                        if (punto1 == false)//toptiene el primer pixel valido dede el eje y
                        {
                            puntoUno.x = i;
                            puntoUno.y = j;
                            punto1 = true;


                            // Color newColor = System.Drawing.Color.Pink;//pongo de color azul
                            // source.SetPixel(i, j, newColor);

                        }
                    }
                }
            }
            //metatarzo ancho del 
            mf = puntoUno.y;

            //punto 2 
            bool punto2 = false;
            Pixel puntoDos = new Pixel(0, 0);

            for (int i = pixelLeft.x; i <= pixelRight.x; i++)
            {
                //busca el punto 2 desde lamitad de la huella mas el 20%
                for (int j = Convert.ToInt32((pixelBottom.y / 2) + (pixelBottom.y / 2) * 0.35); j <= pixelBottom.y; j++)
                {
                    if (pixelValido(source, i, j, source.Width, source.Height))
                    {
                        //top
                        if (punto2 == false)//toptiene el primer pixel valido dede el eje y
                        {
                            puntoDos.x = i;
                            puntoDos.y = j;
                            punto2 = true;
                            // Color newColor = System.Drawing.Color.Red;//pongo de color azul
                            // source.SetPixel(i, j, newColor);

                        }

                    }
                }
            }



            Pixel puntoUnoPrima = new Pixel(puntoUno.x, (mf * 2) - pixelTop.y);

            Pixel puntoUnoPrimaDos = new Pixel(puntoUno.x, (mf * 3) - (pixelTop.y * 2));
            //calculo talon fin 
            Pixel puntoDosFin = new Pixel(0, 0);
            for (int i = pixelLeft.x; i <= pixelRight.x; i++)
            {
                //busca el punto 2 desde lamitad de la huella mas el 20%
                for (int j = puntoUnoPrimaDos.y; j <= pixelBottom.y; j++)
                {
                    if (pixelValido(source, i, j, source.Width, source.Height))
                    {

                        puntoDosFin.x = i;
                        puntoDosFin.y = j;
                    }
                }
            }

            //calculo de archo externo esta ligado al puntouno prima 

            bool punto4 = false;
            Pixel pixelArcoExterno = new Pixel(0, 0);
            Pixel pixelArcoExternoFinal = new Pixel(0, 0);
            for (int i = pixelLeft.x; i <= pixelRight.x; i++)
            {
                for (int j = puntoUnoPrima.y; j <= puntoUnoPrima.y; j++)
                {
                    if (pixelValido(source, i, j, source.Width, source.Height))
                    {
                        //top
                        if (punto4 == false)//toptiene el primer pixel valido dede el eje y
                        {
                            pixelArcoExterno.x = i;
                            pixelArcoExterno.y = j;
                            punto4 = true;
                            // Color newColor = System.Drawing.Color.Red;//pongo de color azul
                            // source.SetPixel(i, j, newColor);

                        }
                        //pixel final 
                        pixelArcoExternoFinal.x = i;
                        pixelArcoExternoFinal.y = j;
                    }
                }
            }

            ///formula calculo plantograma 

            //calcular X 
            bool puntoxFinal = false;
            Pixel puntoX = new Pixel(0, 0);
            Pixel puntoXfinal = new Pixel(0, 0);
            for (int i = 0; i < pixelRight.x; i++)
            {//comienza desde el punto uno mas 10% 
                for (int j = puntoUno.y; j <= puntoUnoPrima.y; j++)
                {
                    if (pixelValido(source, i, j, source.Width, source.Height))
                    {
                        //top
                        if (puntoxFinal == false)//toptiene el primer pixel valido dede el eje y
                        {
                            puntoX.x = i;
                            puntoX.y = j;
                            puntoxFinal = true;
                            // Color newColor = System.Drawing.Color.Red;//pongo de color azul
                            // source.SetPixel(i, j, newColor);

                        }
                        //pixel final 
                        puntoXfinal.x = i;
                        puntoXfinal.y = j;
                    }
                }
            }
            //dibujar lineas
            //dibujar linea top
            dibujarLinea(source, pixelRight.x, pixelTop.y, pixelLeft.x, pixelTop.y, System.Drawing.Color.Yellow);
            //dibujar lina bottoom
            dibujarLinea(source, pixelRight.x, pixelBottom.y, pixelLeft.x, pixelBottom.y, System.Drawing.Color.Blue);
            //dibujar linera left
            dibujarLinea(source, pixelLeft.x, pixelTop.y, pixelLeft.x, pixelBottom.y, System.Drawing.Color.Blue);
            //digujar linea right
            dibujarLinea(source, pixelRight.x, pixelTop.y, pixelRight.x, pixelBottom.y, System.Drawing.Color.Blue);
            //lo que se guarda
            //trazar de punto 1
            dibujarLinea(source, puntoUno.x, puntoUno.y, pixelRight.x, puntoUno.y, System.Drawing.Color.Blue);
            //trazar punto 2 
            dibujarLinea(source, puntoUnoPrima.x, puntoUnoPrima.y, pixelRight.x, puntoUnoPrima.y, System.Drawing.Color.Blue);
            //trazar punto 3
            dibujarLinea(source, puntoUno.x, puntoUnoPrimaDos.y, pixelRight.x, puntoUnoPrimaDos.y, System.Drawing.Color.Blue);
            //trazar de punto 1 a punto2 
            dibujarLinea(source, puntoUno.x, puntoUno.y, puntoDos.x, puntoDos.y, System.Drawing.Color.Red);
            //trazar linea arco externo
            dibujarLinea(source, pixelArcoExterno.x, pixelArcoExterno.y, pixelArcoExternoFinal.x, pixelArcoExternoFinal.y, System.Drawing.Color.Red);

            //dibujar linea punto X final 
            dibujarLinea(source, puntoXfinal.x, puntoUno.y, puntoXfinal.x, puntoUnoPrima.y, System.Drawing.Color.Red);
            //dibujar talon hertical
            dibujarLinea(source, puntoDosFin.x, puntoUnoPrimaDos.y, puntoDosFin.x, pixelBottom.y, System.Drawing.Color.Red);
            //resultado de tipo de pie en porcentaje
            X = puntoXfinal.x - puntoUno.x;//ancho del metatarso
            Y = (pixelArcoExternoFinal.x - pixelArcoExterno.x);//ancho de la impresion
            resultado = CalcularTipoPie(X, Y);
            //resultado espacio interno //ai
            espacioInterno = Convert.ToInt32(pixelArcoExterno.x - puntoUno.x);
            //resultado  talon 
            talon = Convert.ToInt32(puntoDosFin.x - puntoDos.x);
            //medida fundamental mf 
            mf = puntoUno.y - pixelTop.y;

            //Ai
            //X' =X(y'/Y)calcula el valor de x a restar donde se cruza el trrazo dl punto 1 a punto 2  con el x del pixelArcoExterno
            // generamos un triangulo
            int triX = puntoDos.x - puntoUno.x;//base del triangulo
            int triY = puntoDos.y - puntoUno.y;//altura 
            int triYprima = pixelArcoExterno.y - puntoUno.y;//valor en Y que queremos saber 
            float xprima = Convert.ToSingle(triX) * (Convert.ToSingle(triYprima) / Convert.ToSingle(triY));//optiene el valor de X en la altura de Y
            ai = Convert.ToInt32((pixelArcoExterno.x - puntoUno.x) - xprima);
            //longitud pie Y
            longitudPieY = pixelBottom.y - pixelTop.y;
            //logitud pie X
            longitudPieX = pixelRight.x - pixelLeft.x;
            return source;
        }

        public int proyeccionPixelHtml(int original, int proyeccion, int seleccionado)
        {
            int p = 0;
            p = ((seleccionado * original) / proyeccion);
            return p;
        }
        public Bitmap analizarImagenMedoto2(Bitmap source)
        {

            Pixel pixelTop = new Pixel(0, 0);
            Pixel pixelBottom = new Pixel(0, 0);
            Pixel pixelLeft = new Pixel(0, 0);
            Pixel pixelRight = new Pixel(0, 0);
            bool primero = false;
            bool segundo = false;
            //datos iniciales
            /*
            System.Diagnostics.Debug.WriteLine(" sizeImgHTML Width:" + sizeImgHTML.x);
            System.Diagnostics.Debug.WriteLine(" sizeImgHTML Height:" + sizeImgHTML.y);
            System.Diagnostics.Debug.WriteLine(" select html ponit X:" + pixelTopSelect.x);
            System.Diagnostics.Debug.WriteLine(" select html point Y:" + pixelTopSelect.y);*/

            System.Diagnostics.Debug.WriteLine(" original Width:" + source.Width);
            System.Diagnostics.Debug.WriteLine(" original Height:" + source.Height);/*
            Pixel pixelProyeccionTop = new Pixel(proyeccionPixelHtml(source.Width, sizeImgHTML.x, pixelTopSelect.x), proyeccionPixelHtml(source.Height, sizeImgHTML.y, pixelTopSelect.y));
            System.Diagnostics.Debug.WriteLine("select original X:" + pixelProyeccionTop.x);
            System.Diagnostics.Debug.WriteLine("select original Y:" + pixelProyeccionTop.y);*/
            //ancho de metatarzo

            // Recorrer pixel de la imagen para top y bottom
            for (int i = 0; i < source.Height; i++)
            {
                for (int j = 0; j < source.Width; j++)
                {
                    if (pixelValido(source, j, i, source.Width, source.Height))
                    {

                        //top
                        if (primero == false)//toptiene el primer pixel valido dede el eje y
                        {
                            pixelTop.x = j;
                            pixelTop.y = i;
                            primero = true;


                            //Color newColor = System.Drawing.Color.FromArgb(0, 123, 255);//pongo de color azul
                            //source.SetPixel(j, i, newColor);

                        }
                        //bottom  //ultimo pixel yalido desde eje y
                        pixelBottom.x = j;
                        pixelBottom.y = i;
                    }
                }
            }
            // pixelTop = pixelProyeccionTop;
            // Recorrer pixel de la imagen para left  y right
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    if (pixelValido(source, i, j, source.Width, source.Height))
                    {

                        //top
                        if (segundo == false)//toptiene el primer pixel valido dede el eje y
                        {
                            pixelLeft.x = i;
                            pixelLeft.y = j;
                            segundo = true;


                            //Color newColor = System.Drawing.Color.FromArgb(0, 123, 255);//pongo de color azul
                            //source.SetPixel(j, i, newColor);

                        }
                        //bottom  //ultimo pixel yalido desde eje y
                        pixelRight.x = i;
                        pixelRight.y = j;
                    }
                }
            }
            //dibijar top
            dibujarPunto(source, pixelTop.x, pixelTop.y, System.Drawing.Color.Red);
            //dibujar boottom
            dibujarPunto(source, pixelBottom.x, pixelBottom.y, System.Drawing.Color.Yellow);
            //dibujar left
            dibujarPunto(source, pixelLeft.x, pixelLeft.y, System.Drawing.Color.Brown);
            //dibujar Right
            dibujarPunto(source, pixelRight.x, pixelRight.y, System.Drawing.Color.Chocolate);
            /*Init colores*/
            int tamañoTotalY = pixelBottom.y - pixelTop.y;
            int tamSeccion = 0;
            if (tamañoTotalY > 0)
            {
                tamSeccion = tamañoTotalY / 3;
            }

            int contador = 0;
            int tamSeccion1 = tamSeccion * 1;
            int tamSeccion2 = tamSeccion * 2;
            int tamSeccion3 = tamSeccion * 3;
            int totalPixelValidoAP = 0;
            int totalPixelValidoMP = 0;
            int totalPixelValidoRP = 0;
            System.Diagnostics.Debug.WriteLine(" Tamaño seccion:" + tamañoTotalY);
            for (int i = pixelTop.y; i <= pixelBottom.y; i++)
            {
                contador++;
                for (int j = pixelLeft.x; j < pixelRight.x; j++)
                {
                    if (pixelValidoLite(2, source, j, i, source.Width, source.Height))
                    {
                        if (tamSeccion1 >= contador)
                        {//seccion 1
                            dibujarPunto(source, j, i, System.Drawing.Color.Red);
                            totalPixelValidoAP++;
                        }
                        if (contador > tamSeccion1 && tamSeccion2 >= contador)
                        {//seccion 2
                            dibujarPunto(source, j, i, System.Drawing.Color.Blue);
                            totalPixelValidoMP++;
                        }
                        if (contador > tamSeccion2 && tamSeccion3 >= contador)
                        {//seccion 3
                            dibujarPunto(source, j, i, System.Drawing.Color.Green);
                            totalPixelValidoRP++;
                        }
                    }
                }
            }
            double suma = (totalPixelValidoAP + totalPixelValidoMP + totalPixelValidoRP);
            IA = Convert.ToSingle(totalPixelValidoMP / suma);

            System.Diagnostics.Debug.WriteLine("totalPixelValidoAP analisis:" + totalPixelValidoAP);
            System.Diagnostics.Debug.WriteLine("totalPixelValidoMP analisis:" + totalPixelValidoMP);
            System.Diagnostics.Debug.WriteLine("totalPixelValidoRP analisis:" + totalPixelValidoRP);
            System.Diagnostics.Debug.WriteLine("suma IA:" + suma);
            System.Diagnostics.Debug.WriteLine("IA analisis:" + IA);
            /*End colores*/

            //dibujar lineas
            //dibujar linea top
            dibujarLinea(source, pixelRight.x, pixelTop.y, pixelLeft.x, pixelTop.y, System.Drawing.Color.Yellow);
            //dibujar lina bottoom
            dibujarLinea(source, pixelRight.x, pixelBottom.y, pixelLeft.x, pixelBottom.y, System.Drawing.Color.Blue);
            //dibujar linera left
            dibujarLinea(source, pixelLeft.x, pixelTop.y, pixelLeft.x, pixelBottom.y, System.Drawing.Color.Red);
            //digujar linea right
            dibujarLinea(source, pixelRight.x, pixelTop.y, pixelRight.x, pixelBottom.y, System.Drawing.Color.Orange);

            //longitud pie Y
            longitudPieY = pixelBottom.y - pixelTop.y;
            //logitud pie X
            longitudPieX = pixelRight.x - pixelLeft.x;
            return source;
        }
        //pixel valido
        public bool pixelValido(Bitmap bitmap, int i, int j, int with, int heith)
        {
            bool validTop = false;
            bool validButton = false;
            bool validLeft = false;
            bool validRight = false;
            int numeroValido = 0;
            if (i < with && i >= 0 && j < heith && j >= 0)
            {
                Color col = bitmap.GetPixel(i, j);
                // Escala de grises
                byte gray = (byte)(col.R * 0.3f + col.G * 0.59f + col.B * 0.11f);
                if (gray == 0)//middle
                {
                    //top
                    if ((i - 1 >= 0) && (i - 1 < with) && (j >= 0) && (j < heith))
                    {
                        Color col1 = bitmap.GetPixel(i - 1, j);
                        // Escala de grises
                        byte gray1 = (byte)(col1.R * 0.3f + col1.G * 0.59f + col1.B * 0.11f);
                        if (gray1 == 0)
                        {
                            validTop = true;
                            numeroValido++;
                        }
                    }
                    //button
                    if ((i + 1 >= 0) && (i + 1 < with) && (j >= 0) && (j < heith))
                    {
                        Color col2 = bitmap.GetPixel(i + 1, j);
                        // Escala de grises
                        byte gray2 = (byte)(col2.R * 0.3f + col2.G * 0.59f + col2.B * 0.11f);
                        if (gray2 == 0)
                        {
                            validButton = true;
                            numeroValido++;
                        }
                    }
                    //left

                    if ((i >= 0) && (i < with) && (j - 1 >= 0) && (j - 1 < heith))
                    {
                        Color col3 = bitmap.GetPixel(i, j - 1);
                        // Escala de grises
                        byte gray3 = (byte)(col3.R * 0.3f + col3.G * 0.59f + col3.B * 0.11f);
                        if (gray3 == 0)
                        {
                            validLeft = true;
                            numeroValido++;
                        }
                    }

                    //right
                    if ((i >= 0) && (i < with) && (j + 1 >= 0) && (j + 1 < heith))
                    {
                        Color col4 = bitmap.GetPixel(i, j + 1);
                        // Escala de grises
                        byte gray4 = (byte)(col4.R * 0.3f + col4.G * 0.59f + col4.B * 0.11f);
                        if (gray4 == 0)
                        {
                            validRight = true;
                            numeroValido++;
                        }
                    }
                }
            }
            ///mas nitides en el reconocimiento de pixeles
            if (numeroValido >= 4)
            {

                return true;

            }
            else
            {
                return false;
            }

            //return valido;

        }
        public bool pixelValidoLite(int numValido, Bitmap bitmap, int i, int j, int with, int heith)
        {
            bool validTop = false;
            bool validButton = false;
            bool validLeft = false;
            bool validRight = false;
            int numeroValido = 0;
            if (i < with && i >= 0 && j < heith && j >= 0)
            {
                Color col = bitmap.GetPixel(i, j);
                // Escala de grises
                byte gray = (byte)(col.R * 0.3f + col.G * 0.59f + col.B * 0.11f);
                if (gray == 0)//middle
                {
                    //top
                    if ((i - 1 >= 0) && (i - 1 < with) && (j >= 0) && (j < heith))
                    {
                        Color col1 = bitmap.GetPixel(i - 1, j);
                        // Escala de grises
                        byte gray1 = (byte)(col1.R * 0.3f + col1.G * 0.59f + col1.B * 0.11f);
                        if (gray1 == 0)
                        {
                            validTop = true;
                            numeroValido++;
                        }
                    }
                    //button
                    if ((i + 1 >= 0) && (i + 1 < with) && (j >= 0) && (j < heith))
                    {
                        Color col2 = bitmap.GetPixel(i + 1, j);
                        // Escala de grises
                        byte gray2 = (byte)(col2.R * 0.3f + col2.G * 0.59f + col2.B * 0.11f);
                        if (gray2 == 0)
                        {
                            validButton = true;
                            numeroValido++;
                        }
                    }
                    //left

                    if ((i >= 0) && (i < with) && (j - 1 >= 0) && (j - 1 < heith))
                    {
                        Color col3 = bitmap.GetPixel(i, j - 1);
                        // Escala de grises
                        byte gray3 = (byte)(col3.R * 0.3f + col3.G * 0.59f + col3.B * 0.11f);
                        if (gray3 == 0)
                        {
                            validLeft = true;
                            numeroValido++;
                        }
                    }

                    //right
                    if ((i >= 0) && (i < with) && (j + 1 >= 0) && (j + 1 < heith))
                    {
                        Color col4 = bitmap.GetPixel(i, j + 1);
                        // Escala de grises
                        byte gray4 = (byte)(col4.R * 0.3f + col4.G * 0.59f + col4.B * 0.11f);
                        if (gray4 == 0)
                        {
                            validRight = true;
                            numeroValido++;
                        }
                    }
                }
            }
            ///mas nitides en el reconocimiento de pixeles
            if (numeroValido >= numValido)
            {

                return true;

            }
            else
            {
                return false;
            }

            //return valido;

        }
        //dibujar un punto
        public void dibujarPunto(Bitmap bitmap, int x, int y, Color color)
        {
            bitmap.SetPixel(x, y, color);
        }
        //dibuja una linea desdee un punto hasta otro punto
        public static void dibujarLinea(Bitmap bitmap, int origen_x1, int origen_y1, int destino_x2, int destino_y2, Color color)
        {


            Pen pen = new Pen(color, 1);
            // Draw line to screen.
            using (var graphics = Graphics.FromImage(bitmap))
            {

                graphics.DrawLine(pen, new Point(origen_x1, origen_y1), new Point(destino_x2, destino_y2));
            }

        }
        public float CalcularTipoPie(int x, int y)
        {

            float x1 = Convert.ToSingle(x);
            float y1 = Convert.ToSingle(y);
            return ((x1 - y1) / x1) * 100;

        }


        public string mensajeTipoPie(float res)
        {
            string mensage = "";

            if (res >= 0 && res <= 34.9)
            {

                mensage = "pie plano";

            }
            if (res >= 35 && res <= 39.9)
            {

                mensage = "pie plano normal";

            }
            if (res >= 40 && res <= 54.9)
            {

                mensage = "Normal";

            }
            if (res >= 55 && res <= 59.9)
            {

                mensage = "Normal cavo";

            }
            if (res >= 60 && res <= 74.9)
            {

                mensage = "Cavo";

            }
            if (res >= 75 && res <= 84.9)
            {

                mensage = "Cavo Fuerte";

            }
            if (res >= 85 && res <= 100)
            {

                mensage = "Cavo Extremo";

            }

            return mensage;


        }

        public string mensajeTipoPieMetodo2(double IACentimetros)
        {
            string mensage = "";

            if (IACentimetros >= 0 && IACentimetros < 0.21)
            {

                mensage = "Cavo";

            }

            if (IACentimetros >= 0.21 && IACentimetros <= 0.26)
            {

                mensage = "Normal";

            }
            if (IACentimetros > 0.26)
            {

                mensage = "pie plano";

            }


            return mensage;


        }

    }
}
