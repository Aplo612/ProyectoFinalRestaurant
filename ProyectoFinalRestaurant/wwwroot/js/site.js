const botonesMesa = document.querySelectorAll('.mesas button');

botonesMesa.forEach((boton, index) => {
    const mesa = index + 1;
    boton.addEventListener('click', () => {
        localStorage.setItem('numeroMesa', mesa);
        window.location.href = '/plato/mesa';
    });
});