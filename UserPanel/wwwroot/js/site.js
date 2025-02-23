﻿document.getElementById('selectAllCheckbox')
    .addEventListener('change', function () {
        let checkboxes =
            document.querySelectorAll('.checkbox');
        checkboxes.forEach(function (checkbox) {
            checkbox.checked = this.checked;
        }, this);
    });


document.getElementById('blockBtn').addEventListener('click', function () {
    let checkboxes = document.querySelectorAll('.checkbox');
    let checkedUsers = [];

    checkboxes.forEach(function (checkbox) {
        if (checkbox.checked) {
            checkedUsers.push(checkbox.value);
        }
    });

    fetch('/Account/Block', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(checkedUsers)
    }).then(response => {
        if (response.ok) {
            window.location.reload();
        } else {
            console.error('Failed to block users');
        }
    }).catch(error => {
        console.error('Error:', error);
    });
});


document.getElementById('unblockBtn').addEventListener('click', function () {
    let checkboxes = document.querySelectorAll('.checkbox');
    let checkedUsers = [];

    checkboxes.forEach(function (checkbox) {
        if (checkbox.checked) {
            checkedUsers.push(checkbox.value);
        }
    });

    fetch('/Account/Unblock', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(checkedUsers)
    }).then(response => {
        if (response.ok) {
            window.location.reload();
        } else {
            console.error('Failed to unblock users');
        }
    }).catch(error => {
        console.error('Error:', error);
    });
});

document.getElementById('deleteBtn').addEventListener('click', function () {
    let checkboxes = document.querySelectorAll('.checkbox');
    let checkedUsers = [];

    checkboxes.forEach(function (checkbox) {
        if (checkbox.checked) {
            checkedUsers.push(checkbox.value);
        }
    });

    fetch('/Account/Delete', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(checkedUsers)
    }).then(response => {
        if (response.ok) {
            window.location.reload();
        } else {
            console.error('Failed to delete users');
        }
    }).catch(error => {
        console.error('Error:', error);
    });
});

