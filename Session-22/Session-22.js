let reverseBtn = document.querySelector("#reverseBtn");
let inputReverse = document.querySelector("#inputReverse");
let resultReverse = document.querySelector("#outputReverse");

reverseBtn.addEventListener("click", reverseStr);
function reverseStr() {
    resultReverse.textContent = reverseString(inputReverse.value);

}
function reverseString(str) {
    return str.split("").reverse().join("");
}

let palindromeBtn = document.querySelector("#palindromeBtn");
let inputPalindrome = document.querySelector("#inputPalindrome")
let resultPalindrome = document.querySelector("#outputPalindrome");

palindromeBtn.addEventListener("click", isPalindrome);

function isPalindrome() {
    let str = inputPalindrome.value;
    let reversedStr = reverseString(str);
    if (str === reversedStr)
        resultPalindrome.textContent = "True";
    else
        resultPalindrome.textContent = "False";
}

var addBtn = document.querySelector("#addBtn");
var nameInput = document.querySelector("#name");
var surnameInput = document.querySelector("#surname");
var ageInput = document.querySelector("#age");
var genderInput = document.querySelector("#gender");
var customersList = document.querySelector("#customersList");
var selectedName = document.querySelector("#selectedName");
var selectedSurname = document.querySelector("#selectedSurname");
var selectedAge = document.querySelector("#selectedAge");
var selectedGender = document.querySelector("#selectedGender");

let customers = [];

addBtn.addEventListener("click", getInput);

function getInput() {
    var customer = {
        name: nameInput.value,
        surname: surnameInput.value,
        age: ageInput.value,
        gender: genderInput.value
    }
    customers.push(customer);
    addCustomer(customer);
}

function addCustomer(customer) {
    var newLine = document.createElement("tr");
    newLine.addEventListener("click", () => {
        selectedName.value = customer.name;
        selectedSurname.value = customer.surname;
        selectedAge.value = customer.age;
        selectedGender.value = customer.gender;
    });
    newLine.innerHTML = `
            <td>${customer.name}</td>
            <td>${customer.surname}</td>
            <td>${customer.age}</td>
            <td>${customer.gender}</td>
          `;
    customersList.appendChild(newLine);
}


var solveBtn = document.querySelector("#solveBtn");
var firstNumber = document.querySelector("#A");
var secondNumber = document.querySelector("#B");
var result = document.querySelector("#result");

solveBtn.addEventListener("click", () => {
    result.textContent = multiply(firstNumber.value, secondNumber.value);
})


function multiply(a, b) {
    let numberA = parseInt(a);
    let numberB = parseInt(b);
    if (isNaN(numberA) || isNaN(numberB)) {
        return "Both parameters must be numbers.";
    } else {
        return numberA * numberB;
    }
}