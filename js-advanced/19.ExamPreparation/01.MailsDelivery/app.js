function solve() {
  const nameInput = document.getElementById('recipientName');
  const titleInput = document.getElementById('title');
  const messageInput = document.getElementById('message');

  const mailList = document.getElementById('list');
  const deletedList = document.getElementsByClassName('delete-list')[0];
  const sentList = document.getElementsByClassName('sent-list')[0];

  document.getElementById('add').addEventListener('click', (event) => {
    event.preventDefault();

    const name = nameInput.value;
    const title = titleInput.value;
    const message = messageInput.value;

    if (!name || !title || !message) {
      return;
    }

    const li = document.createElement('li');

    //! Please don't do in production code, just saving time
    li.innerHTML = `
    <h4>Title: ${title}</h4>
    <h4>Recipient Name: ${name}</h4>
    <span>${message}</span>
    <div id="list-action">
      <button type="submit" id="send">Send</button>
      <button type="submit" id="delete">Delete</button>
    </div>`;

    li.querySelector('#send').addEventListener('click', sendMail);
    li.querySelector('#delete').addEventListener(
      'click',
      deleteMail.bind(null, li)
    );

    mailList.appendChild(li);

    clearFields();

    function sendMail() {
      const innerLi = document.createElement('li');
      innerLi.innerHTML = `
      <li>
        <span>To: ${name}</span>
        <span>Title: ${title}</span>
        <div class="btn">
          <button type="submit" class="delete">Delete</button>
        </div>
      </li>`;

      innerLi
        .querySelector('.delete')
        .addEventListener('click', deleteMail.bind(null, innerLi));

      sentList.appendChild(innerLi);

      mailList.removeChild(li);
    }

    function deleteMail(element) {
      const deleteLi = document.createElement('li');
      deleteLi.innerHTML = `
      <li>
        <span>To: ${name}</span>
        <span>Title: ${title}</span>
      </li>`;

      deletedList.appendChild(deleteLi);

      element.remove();
    }
  });

  document.getElementById('reset').addEventListener('click', (event) => {
    event.preventDefault();

    clearFields();
  });

  function clearFields() {
    nameInput.value = '';
    titleInput.value = '';
    messageInput.value = '';
  }
}

solve();
