document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("loginForm");
    const msg = document.getElementById("msg");

    if (!form) return;

    form.addEventListener("submit", e => {
        e.preventDefault();

        const email = emailInput.value;
        const password = passwordInput.value;

        if (login(email, password)) {
            window.location.href = "paginicial.html";
        } else {
            msg.textContent = "Email ou password incorretos";
            msg.style.color = "red";
        }
    });
});