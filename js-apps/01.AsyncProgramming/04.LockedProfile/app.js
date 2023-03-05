async function lockedProfile() {
  const response = await fetch(
    'http://localhost:3030/jsonstore/advanced/profiles'
  );

  const json = await response.json();

  const profileDiv = document.getElementsByClassName('profile')[0];
  Object.values(json).forEach((profile, i) => {
    const profileCopy = profileDiv.cloneNode(true);
    const [lockButton, unlockButton, nameInput, emailInput, ageInput] =
      profileCopy.querySelectorAll('input');
    const infoDiv = profileCopy.querySelector('div');
    const showMoreButton = profileCopy.querySelector('button');

    lockButton.name = `user${i + 1}Locked`;
    lockButton.checked = true;

    unlockButton.name = `user${i + 1}Locked`;

    nameInput.name = `user${i + 1}Username`;
    nameInput.value = profile.username;

    emailInput.name = `user${i + 1}Email`;
    emailInput.value = profile.email;

    ageInput.name = `user${i + 1}Age`;
    ageInput.value = profile.age;
    ageInput.type = 'email';

    infoDiv.id = `user${i + 1}HiddenFields`;
    infoDiv.style.display = 'none';

    showMoreButton.addEventListener('click', () => {
      if (lockButton.checked) {
        return;
      }

      if (infoDiv.style.display === 'block') {
        infoDiv.style.display = 'none';
        showMoreButton.textContent = 'Show more';
      } else {
        infoDiv.style.display = 'block';
        showMoreButton.textContent = 'Hide it';
      }
    });

    document.getElementById('main').appendChild(profileCopy);
  });

  profileDiv.remove();
}
