function loadCommits() {
  const username = document.getElementById('username').value;
  const repo = document.getElementById('repo').value;

  fetch(`https://api.github.com/repos/${username}/${repo}/commits`)
    .then((response) => {
      if (response.status !== 200) {
        throw {
          status: response.status,
        };
      }

      return response.json();
    })
    .then((data) =>
      data.forEach((commit) => {
        const li = document.createElement('li');
        li.textContent = `${commit.commit.author.name}: ${commit.commit.message}`;
        document.getElementById('commits').appendChild(li);
      })
    )
    .catch((reason) => {
      const li = document.createElement('li');
      li.textContent = `Error: ${reason.status} (Not Found)`;
      document.getElementById('commits').appendChild(li);
    });
}
