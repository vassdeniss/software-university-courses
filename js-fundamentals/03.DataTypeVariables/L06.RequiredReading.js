function Main(pages, pagesPerHour, deadline) {
    let readTime = pages / pagesPerHour;
    let requiredHours = readTime / deadline;
    console.log(requiredHours);
}