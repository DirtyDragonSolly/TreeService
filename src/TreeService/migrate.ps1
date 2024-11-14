# Create migrations for each context

Add-Migration InitialCreate -Context FoldersContext

# Apply migrations for each context

Update-Database InitialCreate -Context FoldersContext