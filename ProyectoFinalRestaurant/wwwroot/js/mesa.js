//Metodo para obtener el numero de la mesa
const numeroMesa = document.getElementById('numeroMesa');
const mesa = localStorage.getItem('numeroMesa');

if (mesa) {
    numeroMesa.innerText = mesa;
} else {
    numeroMesa.innerText = 'ERROR: número de mesa no encontrado';
}

//Metodo para obtener la confirmacion de todo el pedido
const confirmOrderButton = document.getElementById("confirm-order");
const orderSummary = document.getElementById("order-summary");
const orderTotal = document.getElementById("order-total");

confirmOrderButton.addEventListener("click", () => {
    let total = 0;
    let orderDetails = "";
    let orderDetailsSubmit = "";

    const numeroMesa = document.getElementById("numeroMesa").innerText;
    document.getElementById("numero-mesa-field").value = numeroMesa;
    const itemQuantities = document.getElementsByClassName("item-quantity");

    for (let i = 0; i < itemQuantities.length; i++) {
        const quantity = itemQuantities[i].value;
        if (quantity > 0) {
            const item = itemQuantities[i].parentNode.parentNode.parentNode;
            const itemName = item.getElementsByTagName("h3")[0].innerText;
            const itemPrice = item.getElementsByClassName("amount")[0].innerText.replace("$", "");
            const subtotal = quantity * itemPrice;
            const itemId = item.getElementsByClassName("idplato")[0].value;
            total += subtotal;
            orderDetails += `<li class="lista-ordenada"><div class="d-flex justify-content-between align-items-center"><div class="price">${itemName}: ${quantity} x $${itemPrice} = </div><span class="suma-precios">$${subtotal}</span></div></li>`;
            orderDetailsSubmit += `${itemId},${quantity},${subtotal};`;
        }
    }
    orderDetailsSubmit = orderDetailsSubmit.slice(0, -1);
    orderSummary.innerHTML = orderDetails;
    orderTotal.innerText = "$" + total;
    document.getElementById("order-details-field").value = orderDetailsSubmit;
});