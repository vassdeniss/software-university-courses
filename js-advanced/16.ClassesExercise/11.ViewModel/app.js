class Textbox {
  constructor(selector, regex) {
    this._elements = document.querySelectorAll(selector);
    this._invalidSymbols = regex;

    Array.from(this._elements).forEach((el) => {
      el.addEventListener('input', () => {
        this._value = el.value;
        Array.from(this._elements).forEach((item) => {
          item.value = this._value;
        });
      });
    });
  }

  get elements() {
    return this._elements;
  }

  get value() {
    return this._value;
  }

  set value(text) {
    this._value = text;
    Array.from(this._elements).forEach((el) => {
      el.value = text;
    });
  }

  isValid() {
    return this._invalidSymbols.exec(this.value) === null;
  }
}

let textbox = new Textbox('.textbox', /[^a-zA-Z0-9]/);
let inputs = document.getElementsByClassName('.textbox');

inputs.addEventListener('click', function () {
  console.log(textbox.value);
});
