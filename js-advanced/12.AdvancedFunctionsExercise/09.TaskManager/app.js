function solve() {
  const addButton = document.getElementById('add');

  const [_, openSection, progressSection, completedSection] =
    document.querySelectorAll('section');

  addButton.addEventListener('click', (event) => {
    event.preventDefault();

    const taskTitle = document.getElementById('task').value;
    if (!taskTitle) {
      return;
    }

    const taskDescription = document.getElementById('description').value;
    if (!taskDescription) {
      return;
    }

    const taskDate = document.getElementById('date').value;
    if (!taskDate) {
      return;
    }

    const article = document.createElement('article');

    // Create task title
    const h3 = document.createElement('h3');
    h3.textContent = taskTitle;
    article.appendChild(h3);

    // Create task description
    const desc = document.createElement('p');
    desc.textContent = `Description: ${taskDescription}`;
    article.appendChild(desc);

    // Create task date
    const date = document.createElement('p');
    date.textContent = `Due Date: ${taskDate}`;
    article.appendChild(date);

    // Create div for buttons
    const div = document.createElement('div');
    div.classList.add('flex');

    // Create start button
    const startButton = document.createElement('button');
    startButton.classList.add('green');
    startButton.textContent = 'Start';
    startButton.addEventListener('click', moveToProgress);
    div.appendChild(startButton);

    // Create delete button
    const deleteButton = document.createElement('button');
    deleteButton.classList.add('red');
    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener('click', deleteTask);
    div.appendChild(deleteButton);

    article.appendChild(div);

    // Add task to open section
    openSection.lastElementChild.appendChild(article);

    // Function for deleting task
    function deleteTask() {
      article.remove();
    }

    // Function for moving task to progress
    function moveToProgress() {
      startButton.remove();

      // Create finish button
      const finishButton = document.createElement('button');
      finishButton.classList.add('orange');
      finishButton.textContent = 'Finish';
      finishButton.addEventListener('click', moveToFinish);

      div.appendChild(finishButton);

      // Move to progress section
      progressSection.lastElementChild.appendChild(article);
    }

    // Function for moving task to finish
    function moveToFinish() {
      div.remove();

      // Add task to finish section
      completedSection.lastElementChild.appendChild(article);
    }
  });
}
