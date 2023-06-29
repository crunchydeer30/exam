function validatePassword() {
    let password = document.getElementById("password").value;
    let errorMessage = document.getElementById("error-message");
    errorMessage.innerHTML = "";
  
    if (password.length < 4 || password.length > 10) {
      errorMessage.innerHTML = "Пароль должен быть от 4 до 10 символов";
      return;
    }
  
    if (/^\d/.test(password)) {
      errorMessage.innerHTML = "Пароль не должен начинаться с цифры";
      return;
    }
  
    if (!/\d/.test(password)) {
      errorMessage.innerHTML = "Пароль должен содержать хотя бы одну цифру";
      return;
    }
  
    if (!/^[\w_]{4,10}$/.test(password)) {
      errorMessage.innerHTML = "Пароль может содержать только латинские буквы, цифру и знак подчеркивания и быть от 4 до 10 символов";
      return;
    }
  
    let underscoreCount = password.split("_").length - 1;
    if (underscoreCount > 1) {
      errorMessage.innerHTML = "Пароль может содержать только один знак подчеркивания";
      return;
    }
  
    alert("Пароль валидный");
  }