document.addEventListener("DOMContentLoaded", () => {
  const addToCartButtons = document.querySelectorAll("[data-name]");
  const cartItemsContainer = document.getElementById("cart-items-container");
  const totalPriceElement = document.getElementById("total-price");

  addToCartButtons.forEach((button) => {
    button.addEventListener("click", addToCart);
  });

  cartItemsContainer.addEventListener("click", removeCartItem);

  function addToCart(event) {
    const name = event.target.dataset.name;
    const price = event.target.dataset.price;
    const quantityId = event.target.dataset.quantityId;
    const quantityElement = document.getElementById(quantityId);
    const quantity = parseInt(quantityElement.value);

    let cartItems = [];
    if (localStorage.getItem("cartItems")) {
      cartItems = JSON.parse(localStorage.getItem("cartItems"));
    }

    const existingItemIndex = cartItems.findIndex((item) => item.name === name);
    if (existingItemIndex !== -1) {
      cartItems[existingItemIndex].quantity += quantity;
    } else {
      cartItems.push({ name, price, quantity });
    }

    localStorage.setItem("cartItems", JSON.stringify(cartItems));

    updateCartCounter();
    showCartItems();
    updateTotalPrice();
  }

  function updateCartCounter() {
    const cartItems = localStorage.getItem("cartItems");
    const cartCounter = document.getElementById("cart-counter");
    if (cartItems && cartCounter) {
      const itemCount = JSON.parse(cartItems).reduce(
        (total, item) => total + item.quantity,
        0
      );
      cartCounter.textContent = itemCount;
    }
  }

  function showCartItems() {
    const cartItems = localStorage.getItem("cartItems");
    if (cartItems && cartItemsContainer) {
      const items = JSON.parse(cartItems);
      cartItemsContainer.innerHTML = "";

      items.forEach((item, index) => {
        const cartItemElement = document.createElement("div");
        cartItemElement.classList.add(
          "flex",
          "items-center",
          "justify-between"
        );
        if (index !== items.length - 1) {
          cartItemElement.classList.add("mb-4"); // Класс для отступа
        }
        cartItemElement.innerHTML = `
            <div>
                <h3 class="text-lg font-semibold">${item.name}</h3>
            </div>
            <p class="text-gray-500">${item.price} руб</p>
            <span class="text-gray-700 mx-2">Количество: ${item.quantity}</span>
            <div class="flex items-center">
                <button data-name="${item.name}" class="remove-button bg-red-500 hover:bg-red-600 text-white rounded px-4 py-2 focus:outline-none">
                    Удалить
                </button>
            </div>
        `;

        cartItemsContainer.appendChild(cartItemElement);
      });
    }
  }

  function removeCartItem(event) {
    if (event.target.classList.contains("remove-button")) {
      const itemName = event.target.dataset.name;
      let cartItems = [];
      if (localStorage.getItem("cartItems")) {
        cartItems = JSON.parse(localStorage.getItem("cartItems"));
      }

      const existingItemIndex = cartItems.findIndex(
        (item) => item.name === itemName
      );
      if (existingItemIndex !== -1) {
        const existingItem = cartItems[existingItemIndex];
        existingItem.quantity -= 1;
        if (existingItem.quantity <= 0) {
          cartItems.splice(existingItemIndex, 1);
        }
      }

      localStorage.setItem("cartItems", JSON.stringify(cartItems));

      updateCartCounter();
      showCartItems();
      updateTotalPrice();
    }
  }

  function updateTotalPrice() {
    const cartItems = localStorage.getItem("cartItems");
    if (cartItems && totalPriceElement) {
      const items = JSON.parse(cartItems);
      const totalPrice = items.reduce(
        (total, item) => total + item.price * item.quantity,
        0
      );
      totalPriceElement.textContent = `${totalPrice}`;
    }
  }

  updateCartCounter();
  showCartItems();
  updateTotalPrice();
});
