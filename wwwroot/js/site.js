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

function onUserChoice(choice) {
    var rock = document.getElementById("rock");
    var paper = document.getElementById("paper");
    var scissors = document.getElementById("scissors");

    rock.classList.add("fade-out");
    paper.classList.add("fade-out");
    scissors.classList.add("fade-out");

    setTimeout(function () {
        showComputerChoice(choice);
    }, 500);
}

function showComputerChoice(userChoice) {
    const choices = ["rock", "paper", "scissors"];
    const computerChoice = choices[Math.floor(Math.random() * choices.length)];

    // Fade out the choices container
    $('#choices-container').fadeOut('slow', function () {
        // Set the user's choice image and the computer's choice image
        $('#user-choice').attr('src', `~/image/gameimages/${userChoice}.png`);
        $('#computer-choice').attr('src', `~/image/gameimages/${computerChoice}.png`);

        // Fade in the result container
        $('#result-container').fadeIn('slow');
    });
}

document.getElementById("rock").addEventListener("click", function () {
    onUserChoice("Rock");
});

document.getElementById("paper").addEventListener("click", function () {
    onUserChoice("Paper");
});

document.getElementById("scissors").addEventListener("click", function () {
    onUserChoice("Scissors");
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

