export function createElement(type, content, parent, attributes) {
  const element = document.createElement(type);
  element.textContent = content;

  if (parent) {
    parent.appendChild(element);
  }

  for (const [key, value] of Object.entries(attributes)) {
    element.setAttribute(key, value);
  }

  return element;
}
