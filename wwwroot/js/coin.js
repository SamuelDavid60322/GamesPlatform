function flipCoinAnimation(e) {
    e.preventDefault();
    const coin = document.querySelector('.cf-coin');
    coin.classList.add('animate');
    setTimeout(() => {
        coin.classList.remove('animate');
        e.target.submit();
    }, 2000);
}