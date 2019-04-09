<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="plantograma.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .color-fondo {
            border: solid 2px #000;
        }

        .center {
            display: flex;
            justify-content: center;
            margin-top: 8em;
        }

        .spot {
            color: red;
            background: blue;
        }

        .my-canvas {
            background: #f90000;
        }
    </style>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/app/app.js"></script>
    <script src="../js/tether.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.cookie.js"> </script>
    <script src="../js/jquery.validate.min.js"></script>
    <script src="../js/app/cutIzquierdo.js"></script>
    <script>
        /*
        function showCoords(event) {
         var x = event.clientX;
         var y = event.clientY;
         x = x - event.currentTarget.getBoundingClientRect().left;
         y = y- event.currentTarget.getBoundingClientRect().top;
         //var coords = "X : " + x + ", Y : " + y;
         console.log("X:" + x);
            console.log("Y:"+y);
            //document.getElementById("cordenadas").innerHTML = coords;
            var img = document.getElementById('imgTest'); 
//or however you get a handle to the IMG
            var width = img.clientWidth;
            var height = img.clientHeight;
             document.getElementById("txtTotalX").value = width.toFixed(0) ;
            document.getElementById("txtTotalY").value = height.toFixed(0);
            //posicion actual
            document.getElementById("txtX").value = x.toFixed(0);
            document.getElementById("txtY").value = y.toFixed(0);
        }*/


    </script>
</head>
<body>
    <form id="form1" runat="server" class="center">
        <div>

            <asp:Image ID="imgIzquierdo" runat="server" CssClass="color-fondo"  />
            <div>
                <button type="button" id="btnIniciarIzquierdo">Iniciar</button>
                <button type="button" id="btnCortarIzquierdo">Cortar</button>
                <div id="container">
                    <canvas id="myCanvasIzquierdo" class="my-canvas"></canvas>
                </div>
            </div>
    </form>
</body>
</html>
