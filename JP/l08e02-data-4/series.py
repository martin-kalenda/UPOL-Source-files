import operator
import pathlib
import csv

from statistics import mean

from .index import Index


class Series:
    """Stores a sequence of values indexed by an Index class instance."""

    def __init__(self, values, index=None):
        """Create a new series with given values and index.

        Args:
            values: values to be serialized
            index (optional): class Index instance to index values by, a new one is created if not provided
        """

        if not values:
            raise ValueError("No values were given.")

        if index and not len(index.labels) == len(values):
            raise ValueError(
                "The number of indexes and values to index has to match.")

        if not index:
            index = Index(list(range(len(values))))

        self.index = index
        self.values = values

    def __len__(self):
        """Return amount of values in Series."""
        return len(self.values)

    def __iter__(self):
        """Iterator implementation."""
        yield from self.values
    
    def __getitem__(self, key):
        return self.values[self.index.get_loc(key)]

    def __repr__(self):
        """Return printable representation of Series."""
        output = [f"{index}\t{value}" for index, value in zip(self.index.labels, self.values)]

        return "\n".join(output)

    def __str__(self):
        """Return string representation of Series."""
        return self.__repr__()

    def __add__(self, other):
        """Addition operator implementation."""
        return self._apply_operator(other, operator.add)

    def __sub__(self, other):
        """Subtraction operator implementation."""
        return self._apply_operator(other, operator.sub)

    def __mul__(self, other):
        """Multiplication operator implementation."""
        return self._apply_operator(other, operator.mul)

    def __truediv__(self, other):
        """Division operator implementation."""
        return self._apply_operator(other, operator.truediv)

    def __floordiv__(self, other):
        """Floor division operator implementation."""
        return self._apply_operator(other, operator.floordiv)

    def __mod__(self, other):
        """Mod operator implementation."""
        return self._apply_operator(other, operator.mod)

    def __pow__(self, other):
        """Power operator implementation."""
        return self._apply_operator(other, operator.pow)

    def __round__(self, precision):
        """Round function implementation."""
        return self.apply((lambda x: round(x, precision)))

    @classmethod
    def from_csv(cls, filepath, separator=","):
        """Make Series from CSV input"""
        if not (type(filepath) == type(pathlib.Path()) and filepath.suffix == ".csv"):
            return NotImplemented

        with filepath.open(mode="r") as file:
            input_data = [row for row in csv.reader(file, delimiter=separator)]

            return cls(input_data[1], Index(input_data[0]))

    @property
    def shape(self):
        """Return tuple representing the dimensions of Series."""
        return (len(self), )

    def _apply_operator(self, other, operator):
        if type(other) is not Series:
            raise TypeError("Given arguments is not a Series instance.")

        if (len(self) is not len(other)):
            raise ValueError("Mismatched lenghts.")

        return Series([operator(value_1, value_2) for value_1, value_2 in zip(self.values, other.values)], self.index)

    def items(self):
        """Key-value pair iterator implementation."""
        return zip(self.index.labels, self.values)

    def get(self, key):
        """Return the value from series.values that corresponds to the given key from series.index, return None if key is invalid."""
        try:
            return self[key]
        except:
            return None

    def sum(self):
        """Return the sum of all values in series.values."""
        return sum(self.values)

    def max(self):
        """Return the maximum value from series.values."""
        return max(self.values)

    def min(self):
        """Return the maximum value from series.values."""
        return min(self.values)

    def mean(self):
        """Return the average of values from series.values."""
        return mean(self.values)

    def apply(self, func):
        """Apply the given function to all values in series.values and copy them to a new class Series instance."""
        return Series([value for value in map(func, self.values)], Index(self.index.labels.copy(), self.index.name))

    def abs(self):
        """Apply the abs() function to all values in series.values and copy them to a new class Series instance."""
        return Series.apply(self, abs)