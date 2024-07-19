from .vector import dot_product

def matrix_multiplication(matrix_1, matrix_2):
    """Multiply two matrices.

    Args:
        vector_1: Matrix to be multiplied.
        vector_2: Matrix to be mulitplied by.

    Returns:
        Matrix that represents the multiplication of matrix_1 by matrix_2.
    """

    if not len(matrix_1[0]) == len(matrix_2):
        raise ValueError(f"Matrices have to be of m * n and n * p dimensions! Matrices of {len(matrix_1)} * {len(matrix_1[0])} and {len(matrix_2)} * {len(matrix_2[0])} dimensions were given.")
    
    multiplied_matrix = []
    rows = len(matrix_1)
    columns = len(matrix_2[0])

    for i in range(rows):
        row = []

        for j in range(columns):
            row.append(dot_product(matrix_1[i], [row[j] for row in matrix_2]))
            
        multiplied_matrix.append(row)
    
    return multiplied_matrix


def matrix(shape, fill):
    """Create a new matrix of given dimension filled with a given value.

    Args:
        shape: A tuple representing the amount of rows and columns of the created matrix.
        fill: Value to be set for all elements of the created matrix.

    Returns:
        Matrix of shape(rows, columns) dimensions filled with the value of fill.
    """

    new_matrix = []
    rows, columns = shape

    row = columns * [fill]

    for _ in range(rows):
        new_matrix.append(row.copy())

    return new_matrix


def submatrix(matrix, drop_rows=[], drop_columns=[]):
    """Create a new submatrix from the original one with specified rows and columns removed.

    Args:
        matrix: Matrix to remove given rows and columns from.
        drop_rows: Indexes of rows to be removed.
        drop_columns: Indexes of columns to be removed.

    Returns:
        Submatrix of the given matrix with removed rows and columns.
    """

    new_submatrix = []

    rows = len(matrix)
    columns = len(matrix[0])

    for i in range(rows):
        row = []

        if i in drop_rows:
            i += 1
            continue

        for j in range(columns):
            if j in drop_columns:
                j += 1
                continue
            row.append(matrix[i][j])

        if row:
            new_submatrix.append(row)

    return new_submatrix
