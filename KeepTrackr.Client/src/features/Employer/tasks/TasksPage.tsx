import React, { useState, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { AppDispatch } from '../../../app/store';
import Board from './Board/Board';
import { DragDropContext, Droppable, Draggable, DroppableProvided, DraggableProvided, DropResult } from "react-beautiful-dnd";
import { v4 as uuidv4 } from "uuid";
import Editable from "./Editable/Editable";
import { addBoard, fetchAllBoards, reorderBoard, reorderCard } from './tasksPageSlice';
import { useParams } from 'react-router-dom';
import Grid from '@mui/material/Grid';
import CardDetails from './CardDetails/CardDetails';

function TasksPage() {
    const [data, setData]: any = useState([]);
    const dispatch = useDispatch<AppDispatch>();
    const { company } = useParams<string>();
/*    const  company  = useParams<string>();*/
    const nextOrderValue = useSelector((x: any) => x.tasks.boards.entities.length + 1);
    const boards = useSelector((x: any) => x.tasks.boards.entities);
    const cards = useSelector((x: any) => x.tasks.cards.entities);
    const isCardModalOpened = useSelector((x: any) => x.tasks.openedCardId != '' && x.tasks.openedCardId != undefined && x.tasks.openedCardId != null ? true : false );

    useEffect(() => {
        if (boards.length == 0) dispatch(fetchAllBoards(company));
    });

    const setName = (title: any, bid: any) => {
        const index = data.findIndex((item: any) => item.id === bid);
        const tempData: any = [...data];
        tempData[index].boardName = title;
        setData(tempData);
    };

    const dragCardInBoard = (source: any, destination: any) => {
        let tempData: any = [...data];
        const destinationBoardIdx = tempData.findIndex(
            (item: any) => item.id.toString() === destination.droppableId
        );
        const sourceBoardIdx = tempData.findIndex(
            (item: any) => item.id.toString() === source.droppableId
        );
        tempData[destinationBoardIdx].card.splice(
            destination.index,
            0,
            tempData[sourceBoardIdx].card[source.index]
        );
        tempData[sourceBoardIdx].card.splice(source.index, 1);

        return tempData;
    };

    const addCard = async (title: any, bid: any) => {
        const index = data.findIndex((item: any) => item.id === bid);
        const tempData: any = [...data];
        tempData[index].card.push({
            id: uuidv4(),
            title: title,
            tags: [],
            task: [],
        });
        setData(tempData);

    };

    const removeCard = (boardId: any, cardId: any) => {
        const index = data.findIndex((item: any) => item.id === boardId);
        const tempData: any = [...data];
        const cardIndex = data[index].card.findIndex((item: any) => item.id === cardId);

        tempData[index].card.splice(cardIndex, 1);
        setData(tempData);
    };

    const addBoardHandler = (title: any) => {
        const board = {
            title: title,
            order: nextOrderValue,
            company,
            cards: []
        };
        dispatch(addBoard(board));
    };

    const removeBoard = (bid: any) => {
        const tempData: any = [...data];
        const index = data.findIndex((item: any) => item.id === bid);
        tempData.splice(index, 1);
        setData(tempData);
    };

    const onDragEnd = (result: DropResult) => {
        const { source, destination, type, draggableId } = result;
        if (!destination) return;

/*        if (source.droppableId === destination.droppableId) return;*/

        if (type == "board") {
            dispatch(reorderBoard({ boardid: draggableId, destinationOrder: destination.index, sourceOrder: source.index, company: company }));
        }

        if (type == "card") {
            dispatch(reorderCard({ boardId: destination.droppableId, cardId: draggableId, destinationOrder: destination.index, sourceOrder: source.index, company: company }));
        }
        /*      setData(dragCardInBoard(source, destination));*/
    };

    const updateCard = (bid: any, cid: any, card: any) => {
        const index = data.findIndex((item: any) => item.id === bid);
        if (index < 0) return;

        const tempBoards: any = [...data];
        const cards = tempBoards[index].card;

        const cardIndex = cards.findIndex((item: any) => item.id === cid);
        if (cardIndex < 0) return;

        tempBoards[index].card[cardIndex] = card;
        console.log(tempBoards);
        setData(tempBoards);
    };

    return (
        <DragDropContext onDragEnd={onDragEnd}>
            <div className="task_page">
   
                {isCardModalOpened && <CardDetails />}
                     
                <div className="app_outer">
                    <div className="app_boards">
                        
                            <Droppable droppableId="all-boards" direction="horizontal" type="board">
                                {(provided: DroppableProvided) => (

                                <Grid container style={{ flexWrap: 'nowrap' }} {...provided.droppableProps} ref={provided.innerRef} spacing={2}>
                                
                                    {boards.map((item: any, index: any) => {

                                            return (
                                                <Draggable draggableId={item.id} index={item.order} key={item.id}>

                                                    {(provided: DraggableProvided) => (

                                                        <Grid item style={{ width: "300px" }}   {...provided.draggableProps} {...provided.dragHandleProps} ref={provided.innerRef}>
                                                            <Board
                                                                key={item.id ?? item.title}
                                                                id={item.id ?? item.title}
                                                                name={item.title}
                                                                setName={setName}
                                                                addCard={addCard}
                                                                removeCard={removeCard}
                                                                removeBoard={removeBoard}
                                                                updateCard={updateCard}
                                                            />
                                                        </Grid>

                                                    )}


                                                </Draggable>
                                            )

                                    })}

                                        {provided.placeholder}
                                
                                </Grid>

                                )}

                            </Droppable>
                     


                        <Editable
                            class={"add__board"}
                            name={"Add Board"}
                            btnName={"Add Board"}
                            onSubmit={addBoardHandler}
                            placeholder={"Enter Board  Title"}
                        />
                    </div>
                </div>
            </div>
        </DragDropContext>
    );
}

export default TasksPage;