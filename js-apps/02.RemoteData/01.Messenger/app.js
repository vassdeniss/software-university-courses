function attachEvents() {
  const [author, message, send, refresh] = document.querySelectorAll('input');

  send.addEventListener('click', sendMessage);
  refresh.addEventListener('click', displayMessages);

  const url = 'http://localhost:3030/jsonstore/messenger';

  async function sendMessage() {
    if (!author.value || !message.value) {
      return;
    }

    const data = {
      author: author.value.trim(),
      content: message.value.trim(),
    };

    const options = {
      method: 'post',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    };

    try {
      const response = await fetch(url, options);

      if (!response.ok) {
        throw new Error();
      }

      author.value = '';
      message.value = '';
      return await response.json();
    } catch (error) {
      console.log(error.message);
    }
  }

  async function displayMessages() {
    try {
      const response = await fetch(url);

      if (!response.ok) {
        throw new Error();
      }

      const json = await response.json();

      const comments = Object.values(json).reduce((acc, curr) => {
        acc.push(`${curr.author}: ${curr.content}`);
        return acc;
      }, []);

      document.getElementById('messages').textContent = comments.join('\n');
    } catch (error) {
      console.log(error.message);
    }
  }
}

attachEvents();
