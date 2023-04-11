// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//RPS JS
function handleUserChoice(choice) {
    window.location.href = '/RPS/Play?userChoice=' + choice;
}

document.getElementById('rock').addEventListener('click', function () {
    handleUserChoice('Rock');
});

document.getElementById('paper').addEventListener('click', function () {
    handleUserChoice('Paper');
});

document.getElementById('scissors').addEventListener('click', function () {
    handleUserChoice('Scissors');
});