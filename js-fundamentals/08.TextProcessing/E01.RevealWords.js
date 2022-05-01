function main(words, template) {
    words = words.split(', ');
    for (const word of words) {
        template = template.replace('*'.repeat(word.length), word);
    }
    
    console.log(template);
}
