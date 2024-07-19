class Index:
    """Indexes a sequence of values."""

    def __init__(self, labels, name=""):
        """Create a new index with given labels and name.

        Args:
            labels: values to be indexed
            name (optional): name of the index, defaults to ""
        """

        if not labels:
            raise ValueError("No labels were given.")

        if len(set(labels)) != len(labels):
            raise ValueError("Duplicit label was supplied.")

        self.name = name
        self.labels = list(labels)

    def __len__(self):
        """Return amount of labels in Index."""
        return len(self.labels)

    def __iter__(self):
        """Iterator implementation."""
        yield from self.labels

    def get_loc(self, key):
        """Return the index of a given key."""
        if key not in self.labels:
            raise KeyError(f"Given key not in labels: {key}")
        else:
            return self.labels.index(key)
