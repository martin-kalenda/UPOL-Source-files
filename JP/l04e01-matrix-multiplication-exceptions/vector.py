def dot_product(vector_1, vector_2):
    """Calculate the dot product of given vectors.

    Args:
        vector_1: First vector of length n.
        vector_2: Second vector of length n.

    Returns:
        Dot product of vector_1 and vector_2.
    """
    
    if len(vector_1) != len(vector_2):
        raise ValueError(f"Vectors have to be of the same length! Vectors of lengths {len(vector_1)} and {len(vector_2)} were given.")
            
    product = 0

    for (a, b) in zip(vector_1, vector_2):
        product += a * b

    return product
