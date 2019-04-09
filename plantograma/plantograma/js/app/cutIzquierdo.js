function tabSelectIzquierdo() {
    $('.nav-tabs a[href="#nav-izquierdo"]').tab('show');
}
function tabSelectDerecho() {
    $('.nav-tabs a[href="#nav-derecho"]').tab('show');
}
function LoadScriptIzquierdo() {
    $(document).ready(function () {
        var conditionIzquierdo = false;
        var pointsIzquierdo = [];//holds the mousedown pointsIzquierdo
        this.isOldIEIzquierdo = (window.G_vmlCanvasManager);
        var ctxIzquierdo = null;
        var imageObjIzquierdo = new Image();
        var canvasIzquierdo = null;
        var imgOriginalIzquierdo = null;
        var oldPosXIzquierdo = 0;
        var oldPosYIzquierdo = 0;
        var posXIzquierdo = 0;
        var posYIzquierdo = 0;
        var colorPointIzquierdo = "red";
        var colorBackgroundIzquierdoEdit = "red";
        var colorBackgroundIzquierdo = "white";
        var btnIniciarIzquierdo = $('#btnIniciarIzquierdo');//btn iniciar
        var btnCortarIzquierdo = $('#btnCortarIzquierdo');//btn Cortar
        var nameCanvasIzquierdo = 'myCanvasIzquierdo';//nombre de canvas
        var nameDataIzquierdo = 'ContenidoPages_txtDataIzquierda';//nombre de canvas
        var nameImgOriginalIzquierdo = 'ContenidoPages_imageIzquierdoAnalizado';//img original
        var canvasRefIzquierdo = $('#' + nameCanvasIzquierdo);//canvas ref
        activarBtnIzquierdo(true);
        console.log("inicio de cut izquierdo...");
        var btnCrearImgBlancoNegroIzquierdo = $("#ContenidoPages_btnAnalizarIzquierdo");
        function initIzquierdo() {
            activarBtnIzquierdo(false);
            oldPosXIzquierdo = 0;
            oldPosYIzquierdo = 0;
            posXIzquierdo = 0;
            posYIzquierdo = 0;
            pointsIzquierdo = [];
            conditionIzquierdo = true;
            removePointIzquierdo();
            canvasIzquierdo = document.getElementById(nameCanvasIzquierdo);
            imgOriginalIzquierdo = document.getElementById(nameImgOriginalIzquierdo);
            canvasIzquierdo.width = imgOriginalIzquierdo.clientWidth;
            canvasIzquierdo.height = imgOriginalIzquierdo.clientHeight;
            console.log("width:" + imgOriginalIzquierdo.clientWidth);
            console.log("height:" + imgOriginalIzquierdo.clientHeight);
            if (this.isOldIEIzquierdo) {
                G_vmlCanvasManager.initElement(canvasIzquierdo);
            }
            ctxIzquierdo = canvasIzquierdo.getContext('2d');
            imageObjIzquierdo = new Image();
            // Draw  image onto the canvas
            imageObjIzquierdo.onload = function () {
                ctxIzquierdo.drawImage(imageObjIzquierdo, 0, 0);
            };
            imageObjIzquierdo.src = imgOriginalIzquierdo.src;
            // Switch the blending mode
            ctxIzquierdo.globalCompositeOperation = 'destination-over';
        }
        function activarBtnIzquierdo(stado) {
            if (stado == true) {
                btnIniciarIzquierdo.attr("disabled", false);
                btnCortarIzquierdo.attr("disabled", true);
                canvasRefIzquierdo.delay(3000).css("background-color", colorBackgroundIzquierdo);
            } else {
                btnIniciarIzquierdo.attr("disabled", true);
                btnCortarIzquierdo.attr("disabled", false);
                canvasRefIzquierdo.delay(3000).css("background-color", colorBackgroundIzquierdoEdit);
            }
        }
        function removePointIzquierdo() {
            $('.spot').each(function () {
                $(this).remove();

            });
        }
        btnCrearImgBlancoNegroIzquierdo.click(function () {
            removePointIzquierdo();
        });
        btnIniciarIzquierdo.click(function () {
            initIzquierdo();
        });
        //mousemove event
        canvasRefIzquierdo.mousemove(function (e) {
            if (conditionIzquierdo == true) {
                ctxIzquierdo.beginPath();
                posXIzquierdo = e.offsetX;
                posYIzquierdo = e.offsetY;
                // $('#posXIzquierdo').html(e.offsetX);
                // $('#posYIzquierdo').html(e.offsetY);
                //cada click
            }
        });
        //mousedown event
        canvasRefIzquierdo.mousedown(function (e) {
            if (conditionIzquierdo == true) {
                if (e.which == 1) {
                    var pointer = $('<span class="spot">').css({
                        'position': 'absolute',
                        'background-color': colorPointIzquierdo,
                        'width': '5px',
                        'height': '5px',
                        'top': e.pageY,
                        'left': e.pageX
                    });
                    //store the pointsIzquierdo on mousedown
                    pointsIzquierdo.push(e.pageX, e.pageY);
                    ctxIzquierdo.globalCompositeOperation = 'destination-out';
                    ctxIzquierdo.beginPath();
                    ctxIzquierdo.moveTo(oldPosXIzquierdo, oldPosYIzquierdo);
                    if (oldPosXIzquierdo != '') {
                        ctxIzquierdo.lineTo(posXIzquierdo, posYIzquierdo);

                        ctxIzquierdo.stroke();
                    }
                    oldPosXIzquierdo = e.offsetX;
                    oldPosYIzquierdo = e.offsetY;
                    $(document.body).append(pointer);
                    posXIzquierdo = e.offsetX;
                    posYIzquierdo = e.offsetY;
                }//conditionIzquierdo
            }
        });
        btnCortarIzquierdo.click(function () {
            // console.log("HOla clic");
            activarBtnIzquierdo(true);
            conditionIzquierdo = false;
            removePointIzquierdo();
            ctxIzquierdo.clearRect(0, 0, imgOriginalIzquierdo.clientWidth, imgOriginalIzquierdo.clientHeight);
            ctxIzquierdo.beginPath();
            ctxIzquierdo.width = imgOriginalIzquierdo.clientWidth;
            ctxIzquierdo.height = imgOriginalIzquierdo.clientHeight;
            ctxIzquierdo.globalCompositeOperation = 'destination-over';
            
            //draw the polygon
            setTimeout(function () {
                //console.log(pointsIzquierdo);
                var offset = canvasRefIzquierdo.offset();
                //console.log(offset.left,offset.top);
                for (var i = 0; i < pointsIzquierdo.length; i += 2) {
                    var x = parseInt(jQuery.trim(pointsIzquierdo[i]));
                    var y = parseInt(jQuery.trim(pointsIzquierdo[i + 1]));
                    if (i == 0) {
                        ctxIzquierdo.moveTo(x - offset.left, y - offset.top);
                    } else {
                        ctxIzquierdo.lineTo(x - offset.left, y - offset.top);
                    }
                    //console.log(pointsIzquierdo[i],pointsIzquierdo[i+1])
                }
                if (this.isOldIEIzquierdo) {
                    ctxIzquierdo.fillStyle = '';
                    ctxIzquierdo.fill();
                    var fill = $('fill', canvasIzquierdo).get(0);
                    fill.color = '';
                    fill.src = element.src;
                    fill.type = 'tile';
                    fill.alignShape = false;
                }
                else {
                    var pattern = ctxIzquierdo.createPattern(imageObjIzquierdo, "repeat");
                    ctxIzquierdo.fillStyle = pattern;
                    ctxIzquierdo.fill();

                    var dataurl = canvasIzquierdo.toDataURL("image/png");
                    //cambia el src de la imgen original con un archivo tipo base 64 png 
                    imgOriginalIzquierdo.src = dataurl;
                    document.getElementById(nameDataIzquierdo).value = dataurl;
                }
            }, 20);

        });
    });
}