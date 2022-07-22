import nltk
import spacy
import tensorflow

sentence = "NASA awarded Elon Musk's SpaceX a $2.9 billion contract to build the lunar lander"
tokens = nltk.word_tokenize(sentence)
print (tokens)

tagged = ntlk.pos_tag(tokens)
entities = ntlk.chunk.ne_chunk(tagged)
print (type(entities[0]))
for i in range(len(entities)):
  if (type(entities[i]) == nltk.tree.Tree):
    if (entities[i]._label == 'PERSON' or entities[i]._label == 'ORGANIZATION'):
      print(entities[i])

