let password = document.getElementById('password-register')
let confirm_password = document.getElementById('confirm-password-register')

function validatePassword() {
    if (password.value != confirm_password.value) {
        confirm_password.setCustomValidity("Senhas diferentes!")
    } else {
        confirm_password.setCustomValidity("")
    }
}

password.onchange = validatePassword
confirm_password.onkeyup = validatePassword