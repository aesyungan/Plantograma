function successalert() {
    swal({
        title: "Good job!",
        text: "You clicked the button!",
        icon: "success",
        button: "Aww yiss!",
    });
}
//para q luego de realizar algo se peueda redireccionar a una pagina espacifica
function AlertRedirect(title,text,icon,button,url) {
    swal({
        title: title,
        text: text,
        icon: icon,
        button: button,
    }).then((value) => {
        console.log(value);
        window.location.replace(url);//redirige a login
    });
}
//luego de realizar algo se recarga la pagina
function AlertReload(title, text, icon, button) {
    swal({
        title: title,
        text: text,
        icon: icon,
        button: button,
    }).then((value) => {
        console.log(value);
        window.self.window.self.window.window.location = window.location;//redirige a login
    });
}
//luego de realizar algo sale la alerta
function AlertNoRedirect(title, text, icon, button) {
    swal({
        title: title,
        text: text,
        icon: icon,
        button: button,
    });
}

function successCreateAcount() {
    swal({
        title: "Su Cuenta!",
        text: "Se creo  exitosamente!",
        icon: "success",
        button: "Login",
    }).then((value) => {
        console.log(value);
        window.location.replace('Login');//redirige a login
    });
}

function errorAlertLogin() {
    swal("Error!", "Usuario o Contraseña Incorrectos!", "error");
}

function errorAlertUsuarioExiste() {
    swal("Error!", "Usuario Ya Registrado!", "error");
}

function errorAlertTerminos() {
    swal("Error!", "No ha aceptado los Términos y Condiciones!", "error");
}