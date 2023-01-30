function encodeAndDecodeMessages() {
  const [encodeArea, decodeArea] = document.getElementsByTagName('textarea');
  const [encodeButton, decodeButton] = document.getElementsByTagName('button');

  encodeButton.addEventListener('click', () => {
    let encodedMessage = '';

    [...encodeArea.value].forEach((char) => {
      encodedMessage += String.fromCharCode(char.charCodeAt(0) + 1);
    });

    decodeArea.value = encodedMessage;
    encodeArea.value = '';
  });

  decodeButton.addEventListener('click', () => {
    let decodedMessage = '';

    [...decodeArea.value].forEach((char) => {
      decodedMessage += String.fromCharCode(char.charCodeAt(0) - 1);
    });

    decodeArea.value = decodedMessage;
  });
}
