function HTMLtoPDF() {
    var pdf = new jsPDF('p', 'pt', 'letter');
    source = $('#HTMLtoPDF')[0];
    specialElementHandlers = {
        '#bypassme': function (element, renderer) {
            return true
        }
    }
    margins = {
        top: 50,
        left: 60,
        width: 545
    };
    pdf.fromHTML(
            source // HTML string or DOM elem ref.
            , margins.left // x coord
            , margins.top // y coord
            , {
                'width': margins.width // max width of content on PDF
                , 'elementHandlers': specialElementHandlers
            },
            function (dispose) {
                // dispose: object with X, Y of the last line add to the PDF
                //          this allow the insertion of new lines after html
                pdf.save('html2pdf.pdf');
            }
    )
}

function genPDF() {
    //para que se vea lo que que si esta guardando
    $(".btn-download").removeClass('fa-download');
    $(".btn-download").removeClass('btn');
    $(".btn-download").addClass('fa-spinner');
    $(".btn-download").addClass('fa-spin');
    $(".btn-download").addClass('btn-download-1');


    var element = document.getElementById('HTMLtoPDF');
    var svgElements = $("#HTMLtoPDF").find('svg');

    //replace all svgs with a temp canvas
    svgElements.each(function () {
        var canvas, xml;

        // canvg doesn't cope very well with em font sizes so find the calculated size in pixels and replace it in the element.
        $.each($(this).find('[style*=em]'), function (index, el) {
            $(this).css('font-size', getStyle(el, 'font-size'));
        });

        canvas = document.createElement("canvas");
        canvas.className = "screenShotTempCanvas";
        //convert SVG into a XML string
        xml = (new XMLSerializer()).serializeToString(this);

        // Removing the name space as IE throws an error
        xml = xml.replace(/xmlns=\"http:\/\/www\.w3\.org\/2000\/svg\"/, '');

        //draw the SVG onto a canvas
        canvg(canvas, xml);
        $(canvas).insertAfter(this);
        //hide the SVG element
        $(this).attr('class', 'tempHide');
        $(this).hide();
    });


    html2canvas($("#HTMLtoPDF"), {scale: 2, onrendered: function (canvas) {
            var ctx = canvas.getContext('2d');
            ctx.webkitImageSmoothingEnabled = false;
            ctx.mozImageSmoothingEnabled = false;
            ctx.imageSmoothingEnabled = false;
            var destIMG = canvas.toDataURL("image/png");


            var imgWidth = 210;
            var pageHeight = 296;
            var imgHeight = canvas.height * imgWidth / canvas.width;
            var heightLeft = imgHeight;

            var doc = new jsPDF('p', 'mm');
            var position = 0;

            doc.addImage(destIMG, 'PNG', 0, position, imgWidth, imgHeight);
            heightLeft -= pageHeight;

            while (heightLeft >= 0) {
                position = heightLeft - imgHeight;
                doc.addPage();
                doc.addImage(destIMG, 'PNG', 0, position, imgWidth, imgHeight);
                heightLeft -= pageHeight;
            }
            doc.save('reporte' + '.pdf');
            //dejamos como estaba
            $(".btn-download").addClass('fa-download');
            $(".btn-download").addClass('btn');
            $(".btn-download").removeClass('fa-spinner');
            $(".btn-download").removeClass('fa-spin');
            $(".btn-download").removeClass('btn-download-1');
        }
    });

    $("#HTMLtoPDF").find('.screenShotTempCanvas').remove();
    $("#HTMLtoPDF").find('.tempHide').show().removeClass('tempHide');


}
//function genPDF() {
// var element=document.getElementById('HTMLtoPDF');
//    makeHighResScreenshot(element, 2);
//
//}

var makeHighResScreenshot = function (srcEl, scaleFactor) {

    // Save original size of element
    var originalWidth = srcEl.offsetWidth;
    var originalHeight = srcEl.offsetHeight;
    // Force px size (no %, EMs, etc)
    srcEl.style.width = originalWidth + "px";
    srcEl.style.height = originalHeight + "px";

    // Position the element at the top left of the document because of bugs in html2canvas. The bug exists when supplying a custom canvas, and offsets the rendering on the custom canvas based on the offset of the source element on the page; thus the source element MUST be at 0, 0.
    // See html2canvas issues #790, #820, #893, #922
    srcEl.style.position = "absolute";
    srcEl.style.top = "0";
    srcEl.style.left = "0";

    // Create scaled canvas
    var scaledCanvas = document.createElement("canvas");
    scaledCanvas.width = originalWidth * scaleFactor;
    scaledCanvas.height = originalHeight * scaleFactor;
    scaledCanvas.style.width = originalWidth + "px";
    scaledCanvas.style.height = originalHeight + "px";
    var scaledContext = scaledCanvas.getContext("2d");
    scaledContext.scale(scaleFactor, scaleFactor);

    html2canvas(srcEl, {canvas: scaledCanvas})
            .then(function (canvas) {
                var destIMG = canvas.toDataURL("image/png");
                srcEl.style.display = "none";
                var imgWidth = 210;
                var pageHeight = 295;
                var imgHeight = canvas.height * imgWidth / canvas.width;
                var heightLeft = imgHeight;

                var doc = new jsPDF('p', 'mm');
                var position = 0;

                doc.addImage(destIMG, 'PNG', 0, position, imgWidth, imgHeight);
                heightLeft -= pageHeight;

                while (heightLeft >= 0) {
                    position = heightLeft - imgHeight;
                    doc.addPage();
                    doc.addImage(destIMG, 'PNG', 0, position, imgWidth, imgHeight);
                    heightLeft -= pageHeight;
                }
                doc.save('reporte' + '.pdf');
            });

};

