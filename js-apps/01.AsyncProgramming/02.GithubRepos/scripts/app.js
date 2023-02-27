function loadRepos() {
  const username = document.getElementById('username').value;

  const repos = document.getElementById('repos');
  repos.textContent = '';

  fetch(`https://api.github.com/users/${username}/repos`)
    .then((response) => response.json())
    .then((data) =>
      data.forEach((repo) => {
        const li = document.createElement('li');

        const a = document.createElement('a');
        a.href = repo.html_url;
        a.textContent = repo.full_name;

        li.appendChild(a);
        repos.appendChild(li);
      })
    )
    .catch((reason) => console.error(reason));
}
