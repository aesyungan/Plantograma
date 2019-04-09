
function LoadScriptDerecho() {
    $(document).ready(function () {
        var conditionDerecho = false;
        var pointsDerecho = [];//holds the mousedown pointsDerecho
        this.isOldIEDerecho = (window.G_vmlCanvasManager);
        var ctxDerecho = null;
        var imageObjDerecho = new Image();
        var canvasDerecho = null;
        var imgOriginalDerecho = null;
        var oldPosXDerecho = 0;
        var oldPosYDerecho = 0;
        var posXDerecho = 0;
        var posYDerecho = 0;
        var colorPointDerecho = "red";
        var colorBackgroundDerechoEdit = "red";
        var colorBackgroundDerecho = "white";
        var btnIniciarDerecho = $('#btnIniciarDerecho');//btn iniciar
        var btnCortarDerecho = $('#btnCortarDerecho');//btn Cortar
        var nameCanvasDerecho = 'myCanvasDerecho';//nombre de canvas
        var nameDataDerecho = 'ContenidoPages_txtDataDerecho';//nombre de canvas
        var nameImgOriginalDerecho = 'ContenidoPages_imageDerechoAnalizado';//img original
        var canvasRefDerecho = $('#' + nameCanvasDerecho);//canvas ref
        activarBtnDerecho(true);
        console.log("inicio de cut Derecho...");
        var btnCrearImgBlancoNegroDerecho = $("#ContenidoPages_btnAnalizarDerecho");
        function initDerecho() {
            activarBtnDerecho(false);
            oldPosXDerecho = 0;
            oldPosYDerecho = 0;
            posXDerecho = 0;
            posYDerecho = 0;
            pointsDerecho = [];
            conditionDerecho = true;
            removePointDerecho();
            canvasDerecho = document.getElementById(nameCanvasDerecho);
            imgOriginalDerecho = document.getElementById(nameImgOriginalDerecho);
            canvasDerecho.width = imgOriginalDerecho.clientWidth;
            canvasDerecho.height = imgOriginalDerecho.clientHeight;
            console.log("width:" + imgOriginalDerecho.clientWidth);
            console.log("height:" + imgOriginalDerecho.clientHeight);
            if (this.isOldIEDerecho) {
                G_vmlCanvasManager.initElement(canvasDerecho);
            }
            ctxDerecho = canvasDerecho.getContext('2d');
            imageObjDerecho = new Image();
            // Draw  image onto the canvas
            imageObjDerecho.onload = function () {
                ctxDerecho.drawImage(imageObjDerecho, 0, 0);
            };
            imageObjDerecho.src = imgOriginalDerecho.src;
            // Switch the blending mode
            ctxDerecho.globalCompositeOperation = 'destination-over';
        }
        function activarBtnDerecho(stado) {
            if (stado == true) {
                btnIniciarDerecho.attr("disabled", false);
                btnCortarDerecho.attr("disabled", true);
                canvasRefDerecho.delay(3000).css("background-color", colorBackgroundDerecho);
            } else {
                btnIniciarDerecho.attr("disabled", true);
                btnCortarDerecho.attr("disabled", false);
                canvasRefDerecho.delay(3000).css("background-color", colorBackgroundDerechoEdit);
            }
        }
        function removePointDerecho() {
            $('.spot').each(function () {
                $(this).remove();

            });
        }
        btnCrearImgBlancoNegroDerecho.click(function () {
            removePointDerecho();
        });
        btnIniciarDerecho.click(function () {
            initDerecho();
        });
        //mousemove event
        canvasRefDerecho.mousemove(function (e) {
            if (conditionDerecho == true) {
                ctxDerecho.beginPath();
                posXDerecho = e.offsetX;
                posYDerecho = e.offsetY;
                // $('#posXDerecho').html(e.offsetX);
                // $('#posYDerecho').html(e.offsetY);
                //cada click
            }
        });
        //mousedown event
        canvasRefDerecho.mousedown(function (e) {
            if (conditionDerecho == true) {
                if (e.which == 1) {
                    var pointer = $('<span class="spot">').css({
                        'position': 'absolute',
                        'background-color': colorPointDerecho,
                        'width': '5px',
                        'height': '5px',
                        'top': e.pageY,
                        'left': e.pageX
                    });
                    //store the pointsDerecho on mousedown
                    pointsDerecho.push(e.pageX, e.pageY);
                    ctxDerecho.globalCompositeOperation = 'destination-out';
                    ctxDerecho.beginPath();
                    ctxDerecho.moveTo(oldPosXDerecho, oldPosYDerecho);
                    if (oldPosXDerecho != '') {
                        ctxDerecho.lineTo(posXDerecho, posYDerecho);

                        ctxDerecho.stroke();
                    }
                    oldPosXDerecho = e.offsetX;
                    oldPosYDerecho = e.offsetY;
                    $(document.body).append(pointer);
                    posXDerecho = e.offsetX;
                    posYDerecho = e.offsetY;
                }//conditionDerecho
            }
        });
        btnCortarDerecho.click(function () {
            // console.log("HOla clic");
            activarBtnDerecho(true);
            conditionDerecho = false;
            removePointDerecho();
            ctxDerecho.clearRect(0, 0, imgOriginalDerecho.clientWidth, imgOriginalDerecho.clientHeight);
            ctxDerecho.beginPath();
            ctxDerecho.width = imgOriginalDerecho.clientWidth;
            ctxDerecho.height = imgOriginalDerecho.clientHeight;
            ctxDerecho.globalCompositeOperation = 'destination-over';
            
            //draw the polygon
            setTimeout(function () {
                //console.log(pointsDerecho);
                var offset = canvasRefDerecho.offset();
                //console.log(offset.left,offset.top);
                for (var i = 0; i < pointsDerecho.length; i += 2) {
                    var x = parseInt(jQuery.trim(pointsDerecho[i]));
                    var y = parseInt(jQuery.trim(pointsDerecho[i + 1]));
                    if (i == 0) {
                        ctxDerecho.moveTo(x - offset.left, y - offset.top);
                    } else {
                        ctxDerecho.lineTo(x - offset.left, y - offset.top);
                    }
                    //console.log(pointsDerecho[i],pointsDerecho[i+1])
                }
                if (this.isOldIEDerecho) {
                    ctxDerecho.fillStyle = '';
                    ctxDerecho.fill();
                    var fill = $('fill', canvasDerecho).get(0);
                    fill.color = '';
                    fill.src = element.src;
                    fill.type = 'tile';
                    fill.alignShape = false;
                }
                else {
                    var pattern = ctxDerecho.createPattern(imageObjDerecho, "repeat");
                    ctxDerecho.fillStyle = pattern;
                    ctxDerecho.fill();

                    var dataurl = canvasDerecho.toDataURL("image/png");
                    //cambia el src de la imgen original con un archivo tipo base 64 png 
                    imgOriginalDerecho.src = dataurl;
                    document.getElementById(nameDataDerecho).value = dataurl;
                }
            }, 20);

        });
    });
}