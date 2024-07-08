#!/usr/bin/awk -f

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #
#																																															  #
# Task:																																												  #
#																																															  #
# Implement flipping of table data in awk by the main diagonal (swapping of rows and columns).  #
#	Columns are separated by spaces or tabs.																										  #
#																																															  #
# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

#store each line in a 2D array
{
  for (i=1; i<=NF; i++)  {
    a[NR,i] = $i
  }
}

#check the max amount of fields
NF>p { p = NF }

#concatenate transposed fields and print them
END {
  for(j=1; j<=p; j++) {
    str=a[1,j]
      for(i=2; i<=NR; i++){
        str=str" "a[i,j];
      }
    print str
  }
}
