from nltk import Text, word_tokenize


emma = nltk.Text(nltk.corpus.gutenber.words('austen-emma.txt'))
pos = nltk.pos_tag(emma)
ne_tree = nltk.ne_chunk(pos, binary = False)
entities = []
append = True
for tagged_tree in ne_tree:
  if hasattr(tagged_tree, 'label'):
    entity_name = ' '.join(c[0] for c in tagged_tree.leaves())
    entity_type = tagged_tree.label()
    if (len(entities)==0):
      entities.append([entity_name, entity_type])
    else:
      for j in range(len(entities)):
        if (entity_name == entities[j][0]):
          append = False
          break
      if (j == len(entities)-1 and append == True):
        entities.append([entity_name, entity_type])
      append = True
      
print(entities)
