import pathlib
import csv

from .index import Index
from .series import Series


class DataFrame:
    """Represents a table of values where columns are instances of class Series which are all indexed by a single instance of class Index"""

    def __init__(self, values, columns=None):
        """Create a new dataframe with given values and columns.

        Args:
            values: list of instances of class Series which represent individual columns
            columns (optional): class Index instance to index columns (values) by, a new one is created if not provided
        """

        if not values:
            raise ValueError("No values were given.")

        if columns and not len(columns.labels) == len(values):
            raise ValueError("The number of columns and values has to match.")

        if not columns:
            columns = Index([i for i in range(len(values))])

        self.columns = columns
        self.values = values

    def __len__(self):
        """Return amount of columns in DataFrame."""
        return len(self.columns)

    def __iter__(self):
        """Iterator implementation."""
        yield from self.columns

    def __repr__(self):
        """Return printable represantation of DataFrame."""
        return f"DataFrame{repr(self.shape)}"

    def __str__(self):
        """Return string representation of DataFrame."""
        return self.__repr__()

    @classmethod
    def from_csv(cls, filepath, separator=","):
        """Make DataFrame from CSV input."""
        if not (type(filepath) == type(pathlib.Path()) and filepath.suffix == ".csv"):
            return NotImplemented

        with filepath.open(mode="r") as file:
            input_matrix = [row for row in csv.reader(file, delimiter=separator)]
            values = []

            df_index_data = list(input_matrix.pop(0))
            df_index = Index(name=df_index_data.pop(0), labels=df_index_data)

            input_matrix_T = list(zip(*input_matrix))

            series_index = Index(input_matrix_T.pop(0))

            while input_matrix_T:
                values.append(
                    Series(list(input_matrix_T.pop(0)), series_index))

            return cls(values, df_index)

    @property
    def shape(self):
        """Return tuple representing the dimensions of DataFrame."""
        return (self.values[1].shape[0], len(self.columns))

    @property
    def index(self):
        """Return Index of fist Series in values."""
        return self.values[0].index

    def items(self):
        """Key-value pair iterator implementation."""
        return zip(self.columns, self.values)

    def get(self, key):
        """Return the value from dataframe.values that corresponds to the given key from dataframe.columns, return None if key is invalid."""
        try:
            index = self.columns.get_loc(key)

            return self.values[index]
        except:
            return None
