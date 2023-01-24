function editElement(ref, match, replacer) {
  const content = ref.textContent;
  const matcher = new RegExp(match, 'g');

  ref.textContent = content.replace(matcher, replacer);
}
