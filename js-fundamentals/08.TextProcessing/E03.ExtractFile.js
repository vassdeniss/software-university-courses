function main(path) {
    let fileName = path.substring(path.lastIndexOf('\\') + 1, path.lastIndexOf('.'));
    let fileExtension = path.substring(path.lastIndexOf('.') + 1);
    console.log(`File name: ${fileName}`);
    console.log(`File extension: ${fileExtension}`);
}
