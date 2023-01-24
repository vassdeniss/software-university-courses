function extract(content) {
  const para = document.getElementById(content).textContent;
  const pattern = /\(([^)]+)\)/g;

  const result = [];

  let match = pattern.exec(para);
  while (match) {
    result.push(match[1]);
    match = pattern.exec(para);
  }

  return result.join('; ');
}
