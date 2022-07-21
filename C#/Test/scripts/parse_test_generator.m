data = edfread('../test_generator.edf');
info = edfinfo('../test_generator.edf');
%%
format long;
for n=1:length(data.Properties.VariableNames)
    filename = sprintf('../test_generator_%s', data.Properties.VariableNames{n});
    data_column = [];
    name = data.Properties.VariableNames{n};
    for r = 1:length(data.(name))
       
        data_column = [data_column; data.(name){r}];
    end
%     figure;
%     plot(data_column);
    writematrix(data_column,filename);
end
