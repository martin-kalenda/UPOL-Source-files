#!/usr/bin/awk -f

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #
#																																			#
# Task:																																#
#																																			#
# Implement a simplified version of wc in awk:												#
# 	character counting (including newlines), word counting 						#
# 	(a not empty sequence of characters separated by spaces or tabs)  #
#		and line counting from the input.																	#
#																																			#
# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

BEGIN {
  words=0;
  chars=0;
}

#words += number of fields on current line
#chars += length of current line + newline character
{
  words += NF;
  chars += length + 1;
}

END {
  print NR, words, chars;
}
