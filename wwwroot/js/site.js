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

// Coin flip animation function
function flipCoin() {
    var coin = document.getElementById("coin");
    coin.classList.toggle("cf-coin-flip");
}

// Handle the flip button click
document.getElementById("flipBtn").addEventListener("click", function (event) {
    event.preventDefault();
    flipCoin();

    // Submit the form after the animation has finished
    setTimeout(function () {
        document.querySelector("form").submit();
    }, 10000);
});
