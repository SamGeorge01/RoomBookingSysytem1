let form = document.querySelector("form")

    // First name Validation/
function chkFirstname() {
    let fname = document.getElementById("Firstname");
    if (fname.value.trim() === "") {
        error(fname, "Enter Your Firstname");
    }
    else {
        success(fname);
    }
}

//Last name Validation/
function chkLastname() {
    let lname = document.getElementById("Lastname");
    if (lname.value.trim() === "") {
        error(lname, "Enter your Lastname");
    }
    else {
        success(lname);
    }
}
//Email Validation/
function chkemail() {
    let email = document.getElementById("email");
    const email_id = /^[a-zA-Z0-9.!#$%&'+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)$/;
    if (email.value.trim() === "") {
        error(email, "Enter email!");
    }
    else if (!email.value.match(email_id)) {
        error(email, "Please enter a valid email address!");
    }
    else {
        success(email);
    }
}

//Phone Validation/
function chkphone() {
    let phone = document.getElementById("phone");
    const phoneno = /^\d{10}$/;

    if (phone.value.trim() === "") {
        error(phone, "Enter contact number");
    }
    else if (!phone.value.match(phoneno)) {
        error(phone, "Invalid number");
    }
    else {

        success(phone);
    }
}

//Username Validation/
function chkusername() {
    let ul = document.getElementById("Username");
    let name = document.getElementById("Username").value;
    const uname = /^[a-zA-Z0-9]([.-](?![.-])|[a-zA-Z0-9]){3,18}[a-zA-Z0-9]$/;
    var allNames = [];
    if (ul.value.trim() === "") {
        error(Username, "Enter username");
    }
    else if (!ul.value.match(uname)) {
        error(Username, "Enter a valid Username");
    }
    else if (allNames.includes(name)) {
        error(Username, "Name already exists");
        return -1;
    }
    else {
        success(ul);
        allNames.push(name);
    }

    var li = document.createElement("li");
    li.innerHTML = name;

    ul.appendChild(li);
    document.getElementById("name").value = "";


}

//House Address Validation/
function chkaddress() {
    let addr = document.getElementById("address");
    if (addr.value.trim() === "") {
        error(addr, "Enter Address");
    }
    else {
        success(addr);
    }
}

//Password Validation/
function chkPassword() {
    const passw = /^[A-Za-z]\w{7,14}$/;
    let p1 = document.getElementById("Password");
    if (p1.value.trim() === "") {
        error(p1, "Enter password");
    }
    else if (!p1.value.match(passw)) {
        error(p1, "Enter a strong password that contains at least one numeric digit, one uppercase and one lowercase letter");
    }
    else {
        success(p1);
    }
}

//Confirm Password Validation/
function chkConfirmpassword() {

    let pwd1 = document.getElementById("Password");
    let pwd2 = document.getElementById("Confirmpassword");

    if (pwd2.value.trim() === "") {
        error(pwd2, "Re-enter password");
    }
    else if (!pwd2.value.match(pwd1.value)) {
        error(pwd2, "Passwords does'nt match");
    }
    else {
        success(pwd2);
    }
}

//Submit button(onclick) Validation/
function checkvalidate() {
    chkFirstname();
    chkLastname();
    chkemail();
    chkphone();
    chkusername();
    chkaddress();
    chkPassword();
    chkConfirmpassword();
}



//Error Function/
function error(input, msg) {
    let submitbtn = document.getElementById("submit");
    let parent = input.parentElement;
    let small = parent.querySelector('small');
    small.className = 'smallshown';
    small.innerText = msg;
    submitbtn.disabled = true;
    parent.classList.add("error");
    parent.classList.remove("success");
}

/*Success function */

function success(input) {
    let submitbtn = document.getElementById("submit");
    let parent = input.parentElement;
    let small = parent.querySelector('small');
    small.className = 'smallhidden';
    small.innerHTML = "";
    submitbtn.disabled = false;
    parent.classList.remove("error");
    parent.classList.add("success");
}