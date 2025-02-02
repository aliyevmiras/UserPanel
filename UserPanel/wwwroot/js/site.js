document.getElementById('selectAllCheckbox')
    .addEventListener('change', function () {
        let checkboxes =
            document.querySelectorAll('.checkbox');
        checkboxes.forEach(function (checkbox) {
            checkbox.checked = this.checked;
        }, this);
    });