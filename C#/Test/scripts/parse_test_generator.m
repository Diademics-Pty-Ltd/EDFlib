data = edfread('../test_generator.edf');
info = edfinfo('../test_generator.edf');
%%

for n=1:1
    %h = fopen(sprintf('../test_generator_%s', data.Properties.VariableNames{n}), 'w');
    data_column = [];
     name = data.Properties.VariableNames{n}
    for r = 1:length(data.(name))
       
        data_column = [data_column; data.(name){r}];
    end
    figure;
    plot(data_column);
    %fclose(h);
end
