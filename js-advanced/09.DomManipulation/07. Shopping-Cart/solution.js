function solve() {
  const area = document.getElementsByTagName('textarea')[0];

  const cart = {};
  Array.from(document.getElementsByClassName('add-product')).forEach(
    (button) => {
      button.addEventListener('click', (event) => {
        const product = event.target.parentElement.parentElement;
        const name = product.querySelector(
          '.product-details .product-title'
        ).textContent;
        const price = Number(
          product.querySelector('.product-line-price').textContent
        ).toFixed(2);

        if (!cart.hasOwnProperty(name)) {
          cart[name] = {
            price,
            quantity: 0,
          };
        }

        cart[name].quantity++;

        console.log(cart);
        area.textContent += `Added ${name} for ${price} to the cart.\n`;
      });
    }
  );

  document
    .getElementsByClassName('checkout')[0]
    .addEventListener('click', () => {
      const items = Object.keys(cart).join(', ');
      const total = Object.values(cart).reduce(
        (acc, curr) => acc + curr.price * curr.quantity,
        0
      );
      area.textContent += `You bought ${items} for ${total.toFixed(2)}.`;

      Array.from(document.getElementsByTagName('button')).forEach(
        (button) => (button.disabled = true)
      );
    });
}
