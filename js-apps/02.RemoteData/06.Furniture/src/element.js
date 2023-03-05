export function element(type, props, ...content) {
  const element = document.createElement(type);

  for (const prop in props) {
    element[prop] = props[prop];
  }

  for (let entry of content) {
    if (typeof entry == 'string' || typeof entry == 'number') {
      entry = document.createTextNode(entry);
    }

    element.appendChild(entry);
  }

  return element;
}
