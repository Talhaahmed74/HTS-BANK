// Toggle dropdown content on hover
document.querySelector('.user-info').addEventListener('mouseover', function () {
    document.querySelector('.dropdown-content').style.display = 'block';
});

document.querySelector('.user-info').addEventListener('mouseout', function () {
    document.querySelector('.dropdown-content').style.display = 'none';
});

// Add click event to sidebar buttons
document.querySelectorAll('.sidebar-button').forEach(button => {
    button.addEventListener('click', function () {
        // Remove 'selected' class from all buttons
        document.querySelectorAll('.sidebar-button').forEach(btn => btn.classList.remove('selected'));
        // Add 'selected' class to clicked button
        this.classList.add('selected');
    });
});
s