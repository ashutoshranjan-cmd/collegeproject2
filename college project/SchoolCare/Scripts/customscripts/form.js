let loginBtn = document.getElementById("loginBtn");
let otpBtn = document.getElementById("otpBtn");
let passwordField = document.getElementById("passwordField");


otpBtn.onclick = function () {

    passwordField.style.maxHeight = "0";
    loginBtn.classList.add("disable");
    otpBtn.classList.remove("disable");

}
loginBtn.onclick = function () {

    passwordField.style.maxHeight = "65px";
    otpBtn.classList.add("disable");
    loginBtn.classList.remove("disable");

}
function showpassword() {
    let value = document.getElementById('pass');
    if (value.type === "password") {
        value.type = "text";
    }
    else {
        value.type = "password";
    }
}