function InicioPieIzquierdo(event) {
    var x = event.clientX;
    var y = event.clientY;
    x = x - event.currentTarget.getBoundingClientRect().left;
    y = y - event.currentTarget.getBoundingClientRect().top;
    //var coords = "X : " + x + ", Y : " + y;
    console.log("X:" + x);
    console.log("Y:" + y);
    //document.getElementById("cordenadas").innerHTML = coords;
    var img = document.getElementById('ContenidoPages_imageIzquierdoAnalizado');
    //or however you get a handle to the IMG
    var width = img.clientWidth;
    var height = img.clientHeight;
    document.getElementById("ContenidoPages_txtIzquierdoTotalX").value = Number(width.toFixed(0));
    document.getElementById("ContenidoPages_txtIzquierdoTotalY").value = Number(height.toFixed(0));
    //posicion actual
    document.getElementById("ContenidoPages_txtIzquierdoSelectX").value = Number(x.toFixed(0));
    document.getElementById("ContenidoPages_txtIzquierdoSelectY").value = Number(y.toFixed(0));
}

function InicioPieDerecho(event) {
    var x = event.clientX;
    var y = event.clientY;
    x = x - event.currentTarget.getBoundingClientRect().left;
    y = y - event.currentTarget.getBoundingClientRect().top;
    //var coords = "X : " + x + ", Y : " + y;
    console.log("X:" + x);
    console.log("Y:" + y);
    //document.getElementById("cordenadas").innerHTML = coords;
    var img = document.getElementById('ContenidoPages_imageDerechoAnalizado');
    //or however you get a handle to the IMG
    var width = img.clientWidth;
    var height = img.clientHeight;
    document.getElementById("ContenidoPages_txtDerechoTotalX").value = Number(width.toFixed(0));
    document.getElementById("ContenidoPages_txtDerechoTotalY").value = Number(height.toFixed(0));
    //posicion actual
    document.getElementById("ContenidoPages_txtDerechoSelectX").value = Number(x.toFixed(0));
    document.getElementById("ContenidoPages_txtDerechoSelectY").value = Number(y.toFixed(0));
}